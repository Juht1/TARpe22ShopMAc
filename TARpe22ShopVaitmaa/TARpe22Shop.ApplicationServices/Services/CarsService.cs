using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;

namespace TARpe22ShopVaitmaa.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly IFilesServices _files;

        public CarsServices(TARpe22ShopVaitmaaContext context, IFilesServices files)
        {
            _context = context;
            _files = files;

        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            FileToDatabase file = new FileToDatabase();
            car.Id = dto.Id;
            car.Price = dto.Price;
            car.Type = dto.Type;
            car.Name = dto.Name;
            car.Description = dto.Description;
            car.FuelType = dto.FuelType;
            car.FuelCapacity = dto.FuelCapacity;
            car.FuelConsumption = dto.FuelConsumption;
            car.PassengerCount = dto.PassengerCount;
            car.EnginePower = dto.EnginePower;
            car.DoesHaveAutopilot = dto.DoesHaveAutopilot;
            car.CargoWeight = dto.CargoWeight;
            car.BuiltDate = dto.BuiltDate;
            car.LastMaintenance = dto.LastMaintenance;
            car.MaintenanceCount = dto.MaintenanceCount;
            car.FullTripsCount = dto.FullTripsCount;
            car.MaidenLaunch = dto.MaidenLaunch;
            car.Manufacturer = dto.Manufacturer;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = dto.ModifiedAt;

            await _context.Cars.AddAsync(car);
            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, car);
            }
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Price = dto.Price,
                Type = dto.Type,
                Name = dto.Name,
                Description = dto.Description,
                FuelType = dto.FuelType,
                FuelCapacity = dto.FuelCapacity,
                FuelConsumption = dto.FuelConsumption,
                PassengerCount = dto.PassengerCount,
                EnginePower = dto.EnginePower,
                DoesHaveAutopilot = dto.DoesHaveAutopilot,
                CargoWeight = dto.CargoWeight,
                BuiltDate = dto.BuiltDate,
                LastMaintenance = dto.LastMaintenance,
                MaintenanceCount = dto.MaintenanceCount,
                FullTripsCount = dto.FullTripsCount,
                MaidenLaunch = dto.MaidenLaunch,
                Manufacturer = dto.Manufacturer,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
            };

            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, domain);
            }

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Car> Delete(Guid id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();
            var images = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    CarId = y.CarId
                }).ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images);
            _context.Cars.Remove(carId);

            return carId;

        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
