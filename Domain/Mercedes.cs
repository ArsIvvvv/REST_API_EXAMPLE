namespace CarAPI.Domain
{
    public class Mercedes: Car
    {
        public bool WarrantyYears { get; set; } // Гарантия

        public override void PlaySound()
        {
            Console.WriteLine("Sound Mercedes");
        }

    }
}
