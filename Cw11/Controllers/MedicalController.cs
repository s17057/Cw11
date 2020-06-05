using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cw11.Models;
using Cw11.Services;

namespace Cw11.Controllers
{
    [Route("api/medical")]
    [ApiController]
    public class MedicalController : ControllerBase
    {
        private readonly IMedicalDbService _service;
        public MedicalController(IMedicalDbService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_service.GetDoctors());
        }

        [Route("GetDoctor")]
        [HttpGet("{id}")]
        public IActionResult GetDoctor([FromQuery] int id)
        {
            var doctor = _service.GetDoctor(id);
            if(doctor == null)
            {
                return NotFound("Brak lekarza o podanym numerze!");
            }
            else
            {
                return Ok(doctor);
            }
        }
        [Route("AddDoctor")]
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            var doct = _service.AddDoctor(doctor);
            if (doct == null)
            {
                return NotFound("Niepoprawne lub niekompletne dane lekarza!");
            }
            else
            {
                return Ok(doct);
            }
        }
        [Route("EditDoctor")]
        [HttpPost("{id}")]
        public IActionResult EditDoctor([FromQuery] int id, [FromBody] Doctor req)
        {
            var doct = _service.EditDoctor(id,req);
            if (doct == null)
            {
                return NotFound("Niepoprawny numer lekarza!");
            }
            else
            {
                return Ok(doct);
            }

        }
        [Route("DeleteDoctor")]
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent([FromQuery] int id)
        {
            var isDeleted = _service.DeleteDoctor(id);
            if (isDeleted)
            {
                return Ok("Dane usunięte pomyślnie!");
            }
            else
            {
                return BadRequest("Niepoprawny numer lekarza!");
            }
        }
    }
}