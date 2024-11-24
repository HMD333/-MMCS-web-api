using HPF_2.Models;

namespace HP.Service
{
    public interface IAppointmentService
    {

        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task<bool> AddAsync(Appointment appointment);
        Task DeleteAsync(int id);
    }
}
