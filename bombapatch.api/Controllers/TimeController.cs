using bombapatch.api.Data;
using bombapatch.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace bombapatch.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private TimeData timeData = new TimeData();

        
        public TimeController()
        {
        }

        [HttpGet]
        public IActionResult Get() 
        {
            List<Time> times = timeData.BuscarTodosTimes();


            return Ok(times);
        }

        [HttpPost]
        public IActionResult Post(Time time) 
        {
            timeData.AddTime(time);

            return Ok();
        }


    }
}