using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_2022.Model;

public class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }
    [Range(0, 20000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "Decimal(7,2)")]
    public decimal Price { get; set; } = 5.00M;
    public uint Stock { get; set; } = 0;

}