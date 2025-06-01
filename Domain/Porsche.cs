namespace CarAPI.Domain
{
    public class Porsche: Car
    {
        public int MaxSpeed {  get; set; } // макс скорость
        public override void PlaySound()
        {
            Console.WriteLine("Sound Porsche");
        }

    }
}
