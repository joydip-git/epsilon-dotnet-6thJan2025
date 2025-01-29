using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo.Models
{
    [Table("products")]
    public class Product
    {
        [Key]        
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Column("product_id", TypeName = "int")]
        public int Id { get; set; }

        [Column("product_name", TypeName = "varchar(50)")]
        public required string Name { get; set; }

        [Column("product_description", TypeName = "varchar(MAX)")]
        public string? Description { get; set; }

        [Column("product_price", TypeName = "decimal(18,2)")]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name={Name}, Description={Description}, Price={Price}";
        }
    }
}
