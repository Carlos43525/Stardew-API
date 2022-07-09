using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using StardewAPI.Models;
using StardewAPI.Services;

namespace StardewAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly HttpClient client = new HttpClient();

        public MeasurementController()
        {

        }

        [HttpGet]
        public ActionResult<List<Measurement>> GetAll() =>
            DataService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Measurement> Get(int id)
        {
            var measurement = DataService.Get(id);

            if (measurement is null)
                return NotFound();

            return measurement;
        }

        [HttpPost]
        public async Task<ActionResult> ProvideReading()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/plain"));

            // Use /test
            var stringTask = client.GetStringAsync("");
            //var streamTask = client.GetStreamAsync("");


            var msg = await stringTask;
            
            Console.Write(msg);

            decimal.TryParse(msg, out var result);

            DataService.AddMeasurement(result);

            return StatusCode(200); 
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var measurment = DataService.Get(id);

            if (measurment is null)
                return NotFound();

            DataService.DeleteMeasurement(id);

            return NoContent(); 
        }
    }
}
