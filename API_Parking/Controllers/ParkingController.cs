using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOT_Business.interfaces;
using IOT_Business.DTO;

namespace API_Parking.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {

        private readonly ILogger<ParkingController> _logger;
        private readonly IParkingBusiness _parkingHandler;

        public ParkingController(ILogger<ParkingController> logger, IParkingBusiness parkingHandler)
        {
            _logger = logger;
            _parkingHandler = parkingHandler;
        }

        //https://localhost:6001/parking/entery/1/1/1
        /// <summary>
        /// Registers a new Parking
        /// </summary>
        /// <param name="zone"></param>
        /// <param name="sensor"></param>
        /// <param name="rfid"></param>
        /// <returns></returns>
        [HttpGet("entery/{zone:long}/{sensor:long}/{rfid:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterParkEntery(long zone, long sensor, long rfid)
        {
            if (zone < 0) return BadRequest("zone id must be positive and not null");
            if (sensor < 0) return BadRequest("sensor id must be positive and not null");
            if (rfid < 0) return BadRequest("rfid must not be null");

            Console.WriteLine($"Recieved register for car {rfid}, parking in zone {zone} from sensor {sensor}");

            var parkingReg = new ParkingDTO
            {
                Zone = zone,
                Sensor = sensor,
                RfidCar = rfid
            };

            try
            {
                _parkingHandler.RegisterParkEntery(parkingReg);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem detected when registering park entery");
                return StatusCode(500);
            }

            return Ok();
        }

        //https://localhost:44349/parking/exit/1
        /// <summary>
        /// Handles the deparking of a given car
        /// </summary>
        /// <param name="rfid"></param>
        /// <returns></returns>
        [HttpGet("exit/{rfid:long}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult RegisterParkExit(long rfid)
        {
            if (rfid < 0) return BadRequest("rfid must not be null");

            Console.WriteLine($"Recieved register for car {rfid}");

            try
            {
                _parkingHandler.RegisterParkExit(rfid);
            }
            catch (Exception)
            {
                Console.WriteLine("Problem detected when registering park entery");
                return StatusCode(500);
            }

            return Ok();
        }
    }
}
