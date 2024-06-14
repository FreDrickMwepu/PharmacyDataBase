using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class Contract : BaseEntity
{
    [Key]
    public int ContractID { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Text { get; set; }

    [ForeignKey("PharmaceuticalCompany")]
    public string CompanyName { get; set; }
    public PharmaceuticalCompany PharmaceuticalCompany { get; set; }

    [ForeignKey("Pharmacy")]
    public string PharmacyName { get; set; }
    public Pharmacy Pharmacy { get; set; }

    [ForeignKey("Doctor")]
    public string SupervisorSSN { get; set; }
    public Doctor Supervisor { get; set; }
}