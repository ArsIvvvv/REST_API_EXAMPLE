namespace CarAPI.Domain
{
    public class BMW: Car
    {
        public bool XDrive { get; set; } // Полный привод 
        public override void PlaySound()
        {
            Console.WriteLine("Sound BMW");
        }
    }
}
