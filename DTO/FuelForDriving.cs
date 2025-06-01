using System.ComponentModel.DataAnnotations;

namespace CarAPI.DTO
{
    public class FuelForDriving
    {
        [Required]
        [Range(0,50)]
        public int FuelDriving { get; set; }
    }
}
