using HPF_2.Models;

namespace HPF_2.Servics
{
    public interface IRecordsService
    {
        Task<IEnumerable<PatientHistory>> GetAllAsync();
        Task<PatientHistory> GetPatientByIdAsync(int id);
        Task<PatientHistory> GetDoctorByIdAsync(int id);
    }
}
