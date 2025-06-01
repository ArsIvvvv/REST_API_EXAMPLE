using CarAPI.Data.Entity;
using CarAPI.Domain;
using CarAPI.DTO;

namespace CarAPI.Conventers
{
    public static class Conventer
    {
        public static CarEntity? MapDTOtoEntity(CarDTO carDTO)
        {

            return carDTO switch
            {
                BMWDTO bmwDTO => new BMWEntity
                {
                    Name = bmwDTO.Name!,
                    Manufacturer = bmwDTO.Manufacturer!,
                    XDrive = bmwDTO.XDrive

                },
                MercedesDTO mercedesDto => new MercedesEntity
                {
                    Name = mercedesDto.Name!,
                    Manufacturer = mercedesDto.Manufacturer!,
                    WarrantyYears = mercedesDto.WarrantyYears!

                },
                PorscheDTO porscheDto => new PorscheEntity
                {
                    Name = porscheDto.Name!,
                    Manufacturer = porscheDto.Manufacturer!,
                    MaxSpeed = porscheDto.MaxSpeed!
                },

                _ => null
            };
        }


        public static Car? MapEntityToDomain (CarEntity carEntity)
        {
            return carEntity switch
            {
                BMWEntity bmw => new BMW
                {
                    Name = bmw.Name!,
                    Manufacturer = bmw.Manufacturer!,
                    Fuel = bmw.Fuel!,
                    XDrive = bmw.XDrive

                },
                MercedesEntity mercedes => new Mercedes
                {
                    Name = mercedes.Name!,
                    Manufacturer = mercedes.Manufacturer!,
                    Fuel = mercedes.Fuel!,
                    WarrantyYears = mercedes.WarrantyYears!

                },
                PorscheEntity porsche => new Porsche
                {
                    Name = porsche.Name!,
                    Manufacturer = porsche.Manufacturer!,
                    Fuel = porsche.Fuel!,
                    MaxSpeed = porsche.MaxSpeed!
                },

                _ => null
            };
        }

    }
}
