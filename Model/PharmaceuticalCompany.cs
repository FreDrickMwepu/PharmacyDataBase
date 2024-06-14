using System.ComponentModel.DataAnnotations;

namespace PharmacyDataBase.Model;

public class PharmaceuticalCompany : BaseEntity
{
    [Key]
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}