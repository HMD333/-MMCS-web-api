using HPF_2.Models;

namespace HP.Service
{
    public interface IPatientService
    {

        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task AddAsync(Patient patient, PatientHistory patientHistory);
        Task UpdateAsync(int Doctorid, Patient patient, PatientHistory patientHistory);
        Task DeleteAsync(int id);
    }
}
