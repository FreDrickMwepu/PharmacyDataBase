using Microsoft.EntityFrameworkCore;
using PharmacyDataBase.Data;
using PharmacyDataBase.Model;

namespace PharmacyDataBase.Services;

public class PharmacyServices
{
    private readonly ApplicationDataBaseContext _dbContext;

    public PharmacyServices(ApplicationDataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Get a list of pharmacies
    public async Task<List<Pharmacy>> GetPharmacies()
    {
        return await _dbContext.Pharmacies.ToListAsync();
    }

    // Get a pharmacy by Name
    public async Task<Pharmacy> GetPharmacyByName(string name)
    {
        return await _dbContext.Pharmacies.FindAsync(name);
    }

    // Add a new pharmacy
    public async Task PostPharmacy(Pharmacy pharmacy)
    {
        await _dbContext.Pharmacies.AddAsync(pharmacy);
        await _dbContext.SaveChangesAsync();
    }

    // Update an existing pharmacy
    public async Task UpdatePharmacy(Pharmacy pharmacy)
    {
        _dbContext.Pharmacies.Update(pharmacy);
        await _dbContext.SaveChangesAsync();
    }

    // Delete a pharmacy by Name
    public async Task DeletePharmacy(string name)
    {
        var pharmacy = await _dbContext.Pharmacies.FindAsync(name);
        if (pharmacy != null)
        {
            _dbContext.Pharmacies.Remove(pharmacy);
            await _dbContext.SaveChangesAsync();
        }
    }
}