using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NubimetricsChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private IConfiguration configuration;
        public PaisesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        private List<string> unauthorized = new List<string>() { "BR", "CO" };



        // GET api/<PaisesController>/5
        [HttpGet("{pais}")]
        public ActionResult Get(string pais)
        {
            string urlApiMeliClassifiedLocations = configuration.GetSection("urlApiMeliClassifiedLocations").Value;
            string Pais = pais.ToUpper();
            try
            {
                if (Pais.Equals("AR"))
                {
                    return Ok(ApiMeli(urlApiMeliClassifiedLocations + Pais));
                }
                if (unauthorized.Contains(Pais))
                {
                    return Unauthorized();
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private string ApiMeli(string url)
        {
            string stringResult = "";
            using (var client = new HttpClient())
            {
                var result = client.GetAsync(url).GetAwaiter().GetResult();
                stringResult = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                Console.WriteLine("Respuesta : {0}", stringResult);
                Console.WriteLine();
            }
            return stringResult;
        }

    }
    

}
