using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NubimetricsChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NubimetricsChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedaController : ControllerBase
    {

        private IConfiguration configuration;
        public BusquedaController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        // GET api/<BusquedaController>/5
        [HttpGet("{query}")]
        public ActionResult Get(string query)
        {
            string urlApiMeliSearch = configuration.GetSection("urlApiMeliSearch").Value;
            try
            {
                return Ok(ApiMeli(urlApiMeliSearch + query));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private BusquedaChallenge ApiMeli(string url)
        {
            BusquedaChallenge busquedaResult =null;
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(url).GetAwaiter().GetResult();
                var jsonResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Busqueda busqueda=JsonConvert.DeserializeObject<Busqueda>(jsonResult);
                busquedaResult = new BusquedaChallenge(busqueda);
            }
            return busquedaResult;
        }
    }
}
