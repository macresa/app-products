using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime? UpdatedAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class PostProductDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }


    public class PutProductDTO
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

        [Range(0.0, Double.MaxValue, ErrorMessage = "El precio no puede ser 0")]
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int? Stock { get; set; }
    }

}


