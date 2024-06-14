using System.ComponentModel.DataAnnotations;

namespace PharmacyDataBase.Model;

public class Pharmacy : BaseEntity
{
    [Key]
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public IEnumerable<PharmacyDrug>? PharmacyDrug { get; set; }
}