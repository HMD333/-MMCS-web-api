using HPF_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HP.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly HpContext _context;

        public DoctorService(HpContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
        //public void Add(Doctor Result)
        //{
        //    _context.Add(Result);
        //}

        //public void Delete(Doctor Result)
        //{
        //    _context.Doctors.Remove(Result);
        //}

        //public IEnumerable<Doctor> Get()
        //{
        //    var Result = _context.Doctors.ToList();

        //    return (Result);
        //}

        //public Doctor GetById(int id)
        //{
        //    var Result = _context.Doctors.FirstOrDefault(m => m.Id == id);

        //    return (Result);
        //}

        //public void Save()
        //{
        //    _context.SaveChanges();
        //}

        //public Doctor Update(Doctor Result)
        //{
        //    _context.Update(Result);

        //    return (Result);
        //}
    }
}
