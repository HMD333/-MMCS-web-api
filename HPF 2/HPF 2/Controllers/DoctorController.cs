using HP.Service;
using HPF_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HPF_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorRepository;

        public DoctorsController(IDoctorService doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        // GET: api/doctors
        [HttpGet]
        [Route("/[controller]/All Doctors/")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return Ok(doctors);
        }

        // GET: api/doctors/{id}
        //[HttpGet("{id}")]
        [HttpGet("/[controller]/Detals/id")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/doctors
        [HttpPost]
        [Route("/[controller]/Add a Doctor")]
        public async Task<ActionResult> PostDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _doctorRepository.AddAsync(doctor);
            return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
        }

        // PUT: api/doctors/{id}
        //[HttpPut("{id}")]
        [HttpPut("/[controller]/Edit Doctor/id")]
        public async Task<ActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _doctorRepository.UpdateAsync(doctor);
            return NoContent();
        }

        // DELETE: api/doctors/{id}
        //[HttpDelete("{id}")]
        [HttpDelete("/[controller]/Delete Doctor/id")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            await _doctorRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
