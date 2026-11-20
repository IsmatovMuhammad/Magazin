using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Domain.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal (18,2)")]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
