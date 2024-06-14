using PharmacyDataBase.Model;
using PharmacyDataBase.Data;
using Microsoft.EntityFrameworkCore;

namespace PharmacyDataBase.Services
{
    public class CompanyServices
    {
        private readonly ApplicationDataBaseContext _dbContext;

        public CompanyServices(ApplicationDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PharmaceuticalCompany>> Get()
        {
            return await _dbContext.PharmaceuticalCompanies.ToListAsync();
        }

        public async Task Post(PharmaceuticalCompany company)
        {
            await _dbContext.PharmaceuticalCompanies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}