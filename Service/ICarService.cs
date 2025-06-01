using CarAPI.Domain;
using CarAPI.DTO;
using System.Collections;

namespace CarAPI.Service
{
    public interface ICarService
    {
        Task<bool> AddCarAsync(CarDTO carDTO);
        Task<ICollection> GetCarAllAsync();
        Task<ICar?> GetCarIdAsync(int carId);
        Task<bool> DeleteCarIDAsync(int carID);
        Task<ICar?> DriveCarIdAsync(int id, int fuel);


    }
}
