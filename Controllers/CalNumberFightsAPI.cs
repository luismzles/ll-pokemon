using System;
using Microsoft.AspNetCore.Mvc;
using pokemon.Controllers;

namespace pokemon.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalNumberFightsAPI : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var rng = new Random();
            return "I'm working!";
        }

        [HttpPost]
        public string Post(string[] Pokefight_result)
        {
            string result;
            try 
            {
                int totalFights = CalNumberFights.calculateFights(Pokefight_result);
                result = totalFights.ToString();
            }
            catch (System.ApplicationException ex)
            {
                result = ex.Message;
            }
            return result;
        }
    }
}
