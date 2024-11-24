using HP.Service;
using HPF_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HPF_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentRepository;

        public AppointmentController(IAppointmentService appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        // GET: api/patients
        [HttpGet]
        [Route("/[controller]/All Appointments/")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetPatients()
        {
            var patients = await _appointmentRepository.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patients/{id}
        //[HttpGet("{id}")]
        [HttpGet("/[controller]/Appointment Detals/id")]

        public async Task<ActionResult<Appointment>> GetPatient(int id)
        {
            var patient = await _appointmentRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/patients
        [HttpPost]
        [Route("/[controller]/Add a Appointment")]

        public async Task<ActionResult> PostPatient([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool errordet = await _appointmentRepository.AddAsync(appointment);
            if (errordet)
            {
                return CreatedAtAction(nameof(GetPatient), new { id = appointment.Id }, appointment);
            }
            else
            {
                return BadRequest("PatientHistoryId is not Valid enter a Valid id");
            }
            
        }

        // DELETE: api/patients/{id}
        //[HttpDelete("{id}")]
        [HttpDelete("/[controller]/Delete Appointment/id")]

        public async Task<ActionResult> Deleteappointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _appointmentRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
