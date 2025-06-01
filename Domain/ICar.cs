namespace CarAPI.Domain
{
    public interface ICar
    {
        string Name { get; set; }
        string Manufacturer {  get; set; }
        int Fuel { get; set; }
        void PlaySound();
        void DriveOnCar(int fuel);

    }
}
