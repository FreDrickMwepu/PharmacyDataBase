using PharmacyDataBase.Model;
using PharmacyDataBase.Data;
using Microsoft.EntityFrameworkCore;

namespace PharmacyDataBase.Services
{
    public class DoctorServices
    {
        private readonly ApplicationDataBaseContext _dbContext;

        public DoctorServices(ApplicationDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Doctor>> GetDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }

        public async Task PostDoctor(Doctor doctor)
        {
            if (string.IsNullOrEmpty(doctor.SSN))
                throw new InvalidOperationException("SSN cannot be null or empty.");

            await _dbContext.Doctors.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();
        }
    }
}