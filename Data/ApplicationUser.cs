using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacyDataBase.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Add additional properties here
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        // Add navigation properties for relationships, if necessary
        // For example, if the user has many orders
        // public virtual ICollection<Order> Orders { get; set; }
    }
}