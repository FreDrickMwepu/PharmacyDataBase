using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class Prescription : BaseEntity
{
    [Key]
    public int PrescriptionID { get; set; }
    public DateTime Date { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("Patient")]
    public string PatientSSN { get; set; }
    public Patient Patient { get; set; }

    [ForeignKey("Doctor")]
    public string DoctorSSN { get; set; }
    public Doctor Doctor { get; set; }

    [ForeignKey("Drug")]
    public string DrugTradeName { get; set; }
    public Drug Drug { get; set; }
}