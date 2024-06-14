using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class Doctor : BaseEntity
{
    [Key]
    public string SSN { get; set; }

    [NotMapped]
    public string Name 
    {
        get => $"{FirstName} {LastName}";
        set
        {
            var names = value.Split(' ');
            if (names.Length > 1)
            {
                FirstName = names[0];
                LastName = names[1];
            }
        }
    }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    public string Specialty { get; set; }
    public int YearsOfExperience { get; set; }
    public IEnumerable<Patient>? Patient { get; set; }
}