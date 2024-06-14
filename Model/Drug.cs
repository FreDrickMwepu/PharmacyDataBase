using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class Drug : BaseEntity
{
    [Key]
    public string TradeName { get; set; }
    public string Formula { get; set; }

    [ForeignKey("PharmaceuticalCompany")]
    public string CompanyName { get; set; }
    public PharmaceuticalCompany PharmaceuticalCompany { get; set; }
    public IEnumerable<PharmacyDrug>? PharmacyDrug { get; set; }
}