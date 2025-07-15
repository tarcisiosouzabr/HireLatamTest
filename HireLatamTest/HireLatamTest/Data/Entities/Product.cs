using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HireLatamTest.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        [Required]
        [StringLength(300)]
        public string Name { get; private set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be zero or greater.")]
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void UpdateName(string name)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrEmpty(name);
            if(name.Length > 300)
                throw new ArgumentException("Name cannot exceed 300 characters.", nameof(name));
            this.Name = name;
        }

        public void UpdatePrice(decimal price)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be zero or greater.");
            this.Price = price;
        }
    }
}
