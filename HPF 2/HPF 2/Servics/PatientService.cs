using HPF_2.Models;
using Microsoft.EntityFrameworkCore;

namespace HP.Service
{
    public class PatientService : IPatientService
    {
        private readonly HpContext _context;

        public PatientService(HpContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Patient patient, PatientHistory patientHistory)
        {
            // Add the patient first
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            // Set the PatientId for the PatientHistory
            patientHistory.PatientId = patient.Id;
            patientHistory.TreatmentStat = true;
            patientHistory.Time = DateTime.Now;

            // Add the PatientHistory
            _context.PatientHistories.Add(patientHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Doctorid, Patient patient, PatientHistory PatientHistory)
        {
            // Update the patient information
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();

            // Set the PatientId for the new PatientHistory
            // Set the PatientId for the PatientHistory
            PatientHistory.PatientId = patient.Id;
            PatientHistory.DoctorId = Doctorid;
            PatientHistory.TreatmentStat = true;
            PatientHistory.Time = DateTime.Now;

            // Add the PatientHistory
            _context.PatientHistories.Add(PatientHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await GetByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
    //public void AddPatient(Patient patient)
    //{
    //    _context.Add(patient);
    //}

    //public void AddPatient_History(Patient patient , Doctor doctor)
    //{
    //    _context.PatientHistories.Add(new PatientHistory
    //    {
    //        PatientId = patient.Id,
    //        DoctorId = doctor.Id,
    //        Time = DateTime.Now,
    //        TreatmentStat = false
    //    });
    //}

    //public void DeletePatient(Patient patient)
    //{
    //    _context.Patients.Remove(patient);
    //}

    //public void DeletePatient_History(Patient patient, int id)
    //{
    //    foreach (var Patient_History in _context.PatientHistories.Where(h => h.PatientId == id))
    //    {
    //        _context.PatientHistories.Remove(Patient_History);
    //    }
    //}

    //public Patient FindPatientById(int id)
    //{
    //    var Result = _context.Patients.Find(id);

    //    return (Result);
    //}

    //public async Task<IEnumerable<PatientHistory>> FindPatient_HistoryByPatientId(int id)
    //{
    //    var Result = await _context.PatientHistories.Where(d => d.PatientId == id).ToListAsync();

    //    return (Result);
    //}

    //public async Task<IEnumerable<Patient>> GetPatient()
    //{
    //    var Result = await _context.Patients.ToListAsync();

    //    return (Result);
    //}

    //public Patient GetPatientById(int id)
    //{
    //    var Result = _context.Patients.FirstOrDefault(m => m.Id == id);

    //    return (Result);
    //}

    //public PatientHistory GetPatient_HistorytById(int id)
    //{
    //    var Result = _context.PatientHistories.FirstOrDefault(m => m.Id == id);

    //    return (Result);
    //}

    //public async Task<IEnumerable<PatientHistory>> GetPatient_History()
    //{
    //    var Result = await _context.PatientHistories.ToListAsync();

    //    return (Result);
    //}

    //public bool IfAny(int id)
    //{
    //    return _context.Patients.Any(e => e.Id == id);
    //}

    //public void Save()
    //{
    //    _context.SaveChangesAsync();
    //}

    //public void UpdatePatient(Patient patient)
    //{
    //    _context.Update(patient);
    //}

    //public void UpdatePatient_History(PatientHistory patient_History)
    //{
    //    _context.Update(patient_History);
    //}
}

