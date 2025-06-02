using CarAPI.Domain;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarAPI.DTO
{    // creates objects of a specific type (System.Text.Json will create the objects by itself)
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Manufacturer")]
    [JsonDerivedType(typeof(BMWDTO), "BMW")]
    [JsonDerivedType(typeof(MercedesDTO), "Mercedes")]
    [JsonDerivedType(typeof(PorscheDTO), "Porsche")]
    public class CarDTO
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [JsonIgnore]
        public string Manufacturer { get; set; }
        [JsonIgnore]
        public int Fuel { get; set; }
       
    }
}
