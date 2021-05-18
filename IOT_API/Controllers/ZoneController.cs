using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IOT_Business.DTO;
using IOT_Business.interfaces;
using Microsoft.AspNetCore.Http;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System;

namespace IOT_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZoneController : ControllerBase
    {

        private readonly ILogger<ZoneController> _logger;
        private readonly IZoneBusiness _zoneHandler;

        public ZoneController(ILogger<ZoneController> logger, IZoneBusiness zoneHandler)
        {
            _logger = logger;
            _zoneHandler = zoneHandler;
        }

        //https://localhost:44312/zone/traffic/1/1/1
        /// <summary>
        /// Resgister an entry to a zone by a car.
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="sensor"></param>
        /// <param name="rfid"></param>
        /// <returns></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("traffic/{zone:long}/{sensor:long}/{rfid:long}")]
        //[Route("[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterZonePass(long zone, long sensor, long rfid)
        {
            if (zone < 0) return BadRequest("zone id must be positive and not null");
            if (sensor < 0) return BadRequest("sensor id must be positive and not null");
            if (rfid < 0) return BadRequest("rfid must not be null");

            Console.WriteLine($"Recieved register for car {rfid}, entering zone {zone} from sensor {sensor}");

            var zoneReg = new ZoneInfo
            {
                Zone = zone,
                Sensor = sensor,
                Rfid = rfid
            };

            try
            {
                _zoneHandler.RegisterZone(zoneReg);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem detected when registering Zone Pass");
            }

            return Ok();
        }


        //https://localhost:44312/zone/air/1/1/1?co2=2&co=1
        /// <summary>
        /// This method creates a new reading of a atmosphere reading.
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="sensor"></param>
        /// <param name="co2"></param>
        /// <param name="co"></param>
        /// <param name="hc"></param>
        /// <param name="rcho"></param>
        /// <param name="nox"></param>
        /// <param name="sox"></param>
        /// <param name="mp"></param>
        /// <returns><see cref="ActionResult"/></returns>
        [Microsoft.AspNetCore.Mvc.HttpGet("air/{zone:long}/{sensor:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterGasReading(
            long zone,
            long sensor,
            [FromUri] double co2,
            [FromUri] double co,
            [FromUri] double hc,
            [FromUri] double rcho,
            [FromUri] double nox,
            [FromUri] double sox,
            [FromUri] double mp)
        {
            if (zone < 0) return BadRequest("zone id must be positive and not null");
            if (sensor < 0) return BadRequest("sensor id must be positive and not null");

            if (co2 < 0) return BadRequest("co2 must be positive");
            if (co < 0) return BadRequest("co must be positive");
            if (hc < 0) return BadRequest("hc must be positive");
            if (rcho < 0) return BadRequest("rcho must be positive");
            if (nox < 0) return BadRequest("nox must be positive");
            if (sox < 0) return BadRequest("sox must be positive");
            if (mp < 0) return BadRequest("mp must be positive");

            Console.WriteLine($"Recieved atmosphere register, entering zone {zone} from sensor {sensor}");

            var zoneAtm = new ZoneAtmInfo
            {
                Zone = zone,
                Sensor = sensor,
                Co2 = co2,
                Co = co,
                Hc = hc,
                Rcho = rcho,
                NOx = nox,
                SOx = sox,
                MP = mp
            };

            try
            {
                _zoneHandler.RegisterZoneAtm(zoneAtm);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem detected when registering Gas Reading");
            }

            return Ok();
        }
    }
}
