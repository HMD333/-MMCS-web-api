using HP.Service;
using HPF_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace HPF_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientRepository;

        public PatientsController(IPatientService patientRepository)
        {
            _patientRepository = patientRepository;
        }

        // GET: api/patients
        [HttpGet]
        [Route("/[controller]/All Patients/")]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            var patients = await _patientRepository.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patients/{id}
        [HttpGet("/[controller]/Patient Detals/id")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/patients
        [HttpPost]
        [Route("/[controller]/Add a Patient")]
        public async Task<ActionResult> PostPatient([FromBody] PatientDto patientDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _patientRepository.AddAsync(patientDto.Patient, patientDto.PatientHistory);
            return CreatedAtAction(nameof(GetPatient), new { id = patientDto.Patient.Id }, patientDto.Patient);
        }

        // PUT: api/patients/{id}
        [HttpPut("/[controller]/Edit Patient/id")]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new PatientHistory entry when updating
            await _patientRepository.UpdateAsync(id, patientDto.Patient, patientDto.PatientHistory);
            return NoContent();
        }

        // DELETE: api/patients/{id}
        [HttpDelete("/[controller]/Delete Patient/id")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            await _patientRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
