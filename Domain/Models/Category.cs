using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    public List<Product> Products { get; set; }
}
