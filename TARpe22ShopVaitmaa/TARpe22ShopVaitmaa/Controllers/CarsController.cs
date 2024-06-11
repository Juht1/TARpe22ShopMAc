using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;
using TARpe22ShopVaitmaa.Models.Car;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
                TARpe22ShopVaitmaaContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();
            return View("CreateUpdate", car);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CargoWeight = vm.CargoWeight,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image.gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Name = car.Name;
            vm.Description = car.Description;
            vm.FuelType = car.FuelType;
            vm.FuelCapacity = car.FuelCapacity;
            vm.FuelConsumption = car.FuelConsumption;
            vm.PassengerCount = car.PassengerCount;
            vm.EnginePower = car.EnginePower;
            vm.DoesHaveAutopilot = car.DoesHaveAutopilot;
            vm.CargoWeight = car.CargoWeight;
            vm.BuiltDate = car.BuiltDate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.MaintenanceCount = car.MaintenanceCount;
            vm.FullTripsCount = car.FullTripsCount;
            vm.MaidenLaunch = car.MaidenLaunch;
            vm.Manufacturer = car.Manufacturer;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CargoWeight = vm.CargoWeight,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Name = car.Name;
            vm.Description = car.Description;
            vm.FuelType = car.FuelType;
            vm.FuelCapacity = car.FuelCapacity;
            vm.FuelConsumption = car.FuelConsumption;
            vm.PassengerCount = car.PassengerCount;
            vm.EnginePower = car.EnginePower;
            vm.DoesHaveAutopilot = car.DoesHaveAutopilot;
            vm.CargoWeight = car.CargoWeight;
            vm.BuiltDate = car.BuiltDate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.MaintenanceCount = car.MaintenanceCount;
            vm.FullTripsCount = car.FullTripsCount;
            vm.MaidenLaunch = car.MaidenLaunch;
            vm.Manufacturer = car.Manufacturer;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new ImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                }).ToArrayAsync();

            var vm = new CarDeleteViewModel();


            vm.Id = car.Id;
            vm.Price = car.Price;
            vm.Type = car.Type;
            vm.Name = car.Name;
            vm.Description = car.Description;
            vm.FuelType = car.FuelType;
            vm.FuelCapacity = car.FuelCapacity;
            vm.FuelConsumption = car.FuelConsumption;
            vm.PassengerCount = car.PassengerCount;
            vm.EnginePower = car.EnginePower;
            vm.DoesHaveAutopilot = car.DoesHaveAutopilot;
            vm.CargoWeight = car.CargoWeight;
            vm.BuiltDate = car.BuiltDate;
            vm.LastMaintenance = car.LastMaintenance;
            vm.MaintenanceCount = car.MaintenanceCount;
            vm.FullTripsCount = car.FullTripsCount;
            vm.MaidenLaunch = car.MaidenLaunch;
            vm.Manufacturer = car.Manufacturer;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;
            vm.Image.AddRange(photos);

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);
            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(ImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };
            var image = await _filesServices.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
