using HPF_2.Models;
using Microsoft.EntityFrameworkCore;

namespace HP.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HpContext _context;

        public AppointmentService(HpContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<bool> AddAsync(Appointment appointment)
        {
            var patientHistoryid = _context.PatientHistories.Where(h => h.Id == appointment.PatientHistoryId);
            if(patientHistoryid != null)
            {
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await GetByIdAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();
            }
        }
        //public void AddAppointment(Appointment appointment)
        //{
        //    _context.Appointments.Add(new Appointment
        //    {
        //        PatientHistoryId = appointment.PatientHistoryId,
        //        Duration = appointment.Duration,
        //        Visits = appointment.Visits
        //    });
        //}

        //public void DeleteAppointment(Appointment appointment)
        //{
        //    _context.Appointments.Remove(appointment);
        //}

        //public Appointment FindAppointmenttById(int id)
        //{
        //    var Result = _context.Appointments.Find(id);

        //    return (Result);
        //}

        //public Appointment GetAppointmentById(int id)
        //{
        //    var Result = _context.Appointments.FirstOrDefault(m => m.Id == id);

        //    return (Result);
        //}

        //public async Task<IEnumerable<Appointment>> GetAppointment()
        //{
        //    var Result = await _context.Appointments.ToListAsync();

        //    return (Result);
        //}

        //public bool IfAny(int id)
        //{
        //    return _context.Appointments.Any(e => e.Id == id);
        //}

        //public void UpdateAppointment(Appointment appointment)
        //{
        //    _context.Appointments.Update(appointment);
        //}
    }
}
