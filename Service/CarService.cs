using CarAPI.Data.AppDContext;
using CarAPI.Data.Entity;
using CarAPI.Domain;
using CarAPI.DTO;
using CarAPI.Service;
using Microsoft.EntityFrameworkCore;
using CarAPI.Conventers;
using System.Collections;

namespace CarAPI.Service
{
    public class CarService: ICarService
    {
        private readonly AppDbContext _context;
        public CarService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCarAsync(CarDTO carDTO)
        {
            var car = Conventer.MapDTOtoEntity(carDTO);
            if (car != null)
            {
                await _context.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCarIDAsync(int carId)
        {
           var car = await _context.Cars
                .SingleOrDefaultAsync(x => x.Id == carId);
            if(car != null)
            {
                _context.Remove(car);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ICar?> DriveCarIdAsync(int carId, int fuel)
        {
            var carEntity = await _context.Cars
                .SingleOrDefaultAsync(x => x.Id == carId);
            if (carEntity != null)
            {
                var carDomain = Conventer.MapEntityToDomain(carEntity);
                carDomain.DriveOnCar(fuel);

                carEntity.Fuel = carDomain.Fuel;
                await _context.SaveChangesAsync();
                return carDomain;
            }
             return null;
        }

        public async Task<ICollection> GetCarAllAsync()
        {
            var cars = await _context.Cars
                .ToListAsync();

            return cars
                .Select(Conventer.MapEntityToDomain) // Select используется для определения формата
                .ToList();
        }

        public async Task<ICar?> GetCarIdAsync(int carId)
        {
            var car =  await _context.Cars
                .SingleOrDefaultAsync(x => x.Id == carId);

            if(car != null)
            {
                return Conventer.MapEntityToDomain(car);
            }

            return null;

        }
    }
}
