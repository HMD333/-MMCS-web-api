using HPF_2.Models;
using HPF_2.Servics;
using Microsoft.AspNetCore.Mvc;

namespace HPF_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly IRecordsService _recordRepository;

        public RecordsController(IRecordsService recordRepository)
        {
            _recordRepository = recordRepository;
        }

        // GET: api/patients
        [HttpGet]
        [Route("/[controller]/All Records/")]
        public async Task<ActionResult<IEnumerable<PatientHistory>>> GetRecords()
        {
            var patients = await _recordRepository.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patients/{id}
        [HttpGet("/[controller]/Get Doctor Records/id")]
        public async Task<ActionResult<PatientHistory>> GetDoctor(int id)
        {
            var Doctor = await _recordRepository.GetDoctorByIdAsync(id);
            if (Doctor == null)
            {
                return NotFound();
            }
            return Ok(Doctor);
        }

        [HttpGet("/[controller]/Get Patient Records/id")]
        public async Task<ActionResult<PatientHistory>> GetPatient(int id)
        {
            var patient = await _recordRepository.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
