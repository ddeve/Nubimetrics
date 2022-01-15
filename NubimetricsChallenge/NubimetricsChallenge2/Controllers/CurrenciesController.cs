using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NubimetricsChallenge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NubimetricsChallenge2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private IConfiguration configuration;
        public CurrenciesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // GET api/<CurrenciesController>
        [HttpGet()]
        public ActionResult Get()
        {
            try
            {
                return GenerateJsonAndCsvCurrenciesApiMeliFiles();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private ActionResult GenerateJsonAndCsvCurrenciesApiMeliFiles()
        {
            string urlApiMeliCurrencies = configuration.GetSection("urlApiMeliCurrencies").Value;
            string urlApiMeliCurrencyConversions = configuration.GetSection("urlApiMeliCurrencyConversions").Value;
            string jsonString = "";
            string csvString = "";
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(urlApiMeliCurrencies).GetAwaiter().GetResult();
                var jsonResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                List<Currency> currencies = JsonConvert.DeserializeObject<List<Currency>>(jsonResult);
                List<CurrencyChallenge> listaCurrencies = new List<CurrencyChallenge>();
                foreach (Currency currency in currencies)
                {
                    string urlConversion = urlApiMeliCurrencyConversions.Replace("XXX", currency.id);
                    result = client.GetAsync(urlConversion).GetAwaiter().GetResult();
                    jsonResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    CurrencyConvertion currencyConvertion = JsonConvert.DeserializeObject<CurrencyConvertion>(jsonResult);
                    listaCurrencies.Add(new CurrencyChallenge(currency, currencyConvertion));
                    csvString += currencyConvertion.ratio.ToString().Replace(",",".")+",";
                }
                jsonString = JsonConvert.SerializeObject(listaCurrencies);
            }
            System.IO.File.WriteAllText("Currencies.json", jsonString);
            System.IO.File.WriteAllText("CurrencyConvertions.csv", csvString.TrimEnd(','));

            return Ok("Se generaron los archivos Currencies.json y CurrencyConvertions.csv");
        }
    }
}
