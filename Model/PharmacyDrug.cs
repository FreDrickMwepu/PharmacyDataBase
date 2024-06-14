using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class PharmacyDrug : BaseEntity
{
    [Key, Column(Order = 0)]
    [ForeignKey("Pharmacy")]
    public string PharmacyName { get; set; }
    public Pharmacy Pharmacy { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Drug")]
    public string DrugTradeName { get; set; }
    public Drug Drug { get; set; }

    public decimal Price { get; set; }
}