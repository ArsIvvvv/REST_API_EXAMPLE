using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarAPI.Domain
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Manufacturer")]
    [JsonDerivedType(typeof(BMW), "BMW")]
    [JsonDerivedType(typeof(Mercedes), "Mercedes")]
    [JsonDerivedType(typeof(Porsche), "Porsche")]
    public class Car: ICar
    {
        public string Name {get ;set;}
        [JsonIgnore]
        public string Manufacturer { get;set;}

        public int Fuel { get;set;}


        public virtual void PlaySound() 
        {
            Console.WriteLine("some sound");
        }

        public void DriveOnCar(int fuel)
        {
            Fuel -= fuel;
            Console.WriteLine($"{Name},({Manufacturer}): We spent that much {fuel}");
        }
    }
}
