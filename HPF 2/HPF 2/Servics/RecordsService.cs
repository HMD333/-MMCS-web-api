using HPF_2.Models;
using Microsoft.EntityFrameworkCore;

namespace HPF_2.Servics
{
    public class RecordsService : IRecordsService
    {
        private readonly HpContext _context;

        public RecordsService(HpContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PatientHistory>> GetAllAsync()
        {
            return await _context.PatientHistories.ToListAsync();
        }

        public async Task<PatientHistory> GetDoctorByIdAsync(int id)
        {
            return await _context.PatientHistories.FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<PatientHistory> GetPatientByIdAsync(int id)
        {
            return await _context.PatientHistories.FirstOrDefaultAsync(d => d.PatientId == id);
        }
    }
}
