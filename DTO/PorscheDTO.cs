namespace CarAPI.DTO
{
    public class PorscheDTO: CarDTO
    {
        public int MaxSpeed { get; set; } = new Random().Next(200, 240);

    }
}
