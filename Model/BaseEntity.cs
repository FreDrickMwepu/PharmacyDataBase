namespace PharmacyDataBase.Model;

public class BaseEntity 
{
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
}