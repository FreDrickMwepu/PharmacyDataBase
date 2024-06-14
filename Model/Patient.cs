using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Model;

public class Patient : BaseEntity
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

    [NotMapped]
    public string FirstName { get; set; }

    [NotMapped]
    public string LastName { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }

    [ForeignKey("Doctor")]
    public string PrimaryPhysicianSSN { get; set; }
    public Doctor PrimaryPhysician { get; set; }
}