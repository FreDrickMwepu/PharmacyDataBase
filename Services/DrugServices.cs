using Microsoft.EntityFrameworkCore;
using PharmacyDataBase.Data;
using PharmacyDataBase.Model;

namespace PharmacyDataBase.Services;

public class DrugServices
{
            private readonly ApplicationDataBaseContext _dbContext;

        public DrugServices(ApplicationDataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get a list of drugs
        public async Task<List<Drug>> GetDrugs()
        {
            return await _dbContext.Drugs.ToListAsync();
        }

        // Get a drug by trade name
        public async Task<Drug> GetDrugByTradeName(string tradeName)
        {
            return await _dbContext.Drugs.FindAsync(tradeName);
        }

        // Add a new drug
        public async Task PostDrug(Drug drug)
        {
            await _dbContext.Drugs.AddAsync(drug);
            await _dbContext.SaveChangesAsync();
        }

        // Update an existing drug
        public async Task UpdateDrug(Drug drug)
        {
            _dbContext.Drugs.Update(drug);
            await _dbContext.SaveChangesAsync();
        }

        // Delete a drug by trade name
        public async Task DeleteDrug(string tradeName)
        {
            var drug = await _dbContext.Drugs.FindAsync(tradeName);
            if (drug != null)
            {
                _dbContext.Drugs.Remove(drug);
                await _dbContext.SaveChangesAsync();
            }
        }
}