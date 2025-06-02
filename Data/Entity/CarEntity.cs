using System.ComponentModel.DataAnnotations;

namespace CarAPI.Data.Entity
{
    public abstract class CarEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        [Range(0, 100)]
        public int Fuel { get; set; } = 100;
    }
}
