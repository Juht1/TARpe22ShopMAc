﻿using Microsoft.EntityFrameworkCore;
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
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly IFilesServices _files;

        public SpaceshipsServices(TARpe22ShopVaitmaaContext context, IFilesServices files)
        {
            _context = context;
            _files = files;

        }

        public async Task<Spaceship> Create(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();
            spaceship.Id = dto.Id;
            spaceship.Price = dto.Price;
            spaceship.Type = dto.Type;
            spaceship.Name = dto.Name;
            spaceship.Description = dto.Description;
            spaceship.FuelType = dto.FuelType;
            spaceship.FuelCapacity = dto.FuelCapacity;
            spaceship.FuelConsumption = dto.FuelConsumption;
            spaceship.PassengerCount = dto.PassengerCount;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.DoesHaveAutopilot = dto.DoesHaveAutopilot;
            spaceship.CrewCount = dto.CrewCount;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.DoesHaveLifeSupportSystems = dto.DoesHaveLifeSupportSystems;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.LastMaintenance = dto.LastMaintenance;
            spaceship.MaintenanceCount = dto.MaintenanceCount;
            spaceship.FullTripsCount = dto.FullTripsCount;
            spaceship.MaidenLaunch = dto.MaidenLaunch;
            spaceship.Manufacturer = dto.Manufacturer;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt;

            await _context.Spaceships.AddAsync(spaceship);
            if (dto.Files != null)
            {
                _files.UploadFilesToDatabase(dto, spaceship);
            }
            await _context.SaveChangesAsync();

            return spaceship; 
        }
        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            var domain = new Spaceship()
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
                CrewCount = dto.CrewCount,
                CargoWeight = dto.CargoWeight,
                DoesHaveLifeSupportSystems = dto.DoesHaveLifeSupportSystems,
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

            _context.Spaceships.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();
            var images = await _context.FilesToDatabase
                .Where(x => x.SpaceshipId == id)
                .Select(y => new FileToDatabaseDto
                {
                    Id = y.Id,
                    ImageTitle = y.ImageTitle,
                    SpaceshipId = y.SpaceshipId
                }).ToArrayAsync();

            await _files.RemoveImagesFromDatabase(images);
            _context.Spaceships.Remove(spaceshipId);

            return spaceshipId;

        }
        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
