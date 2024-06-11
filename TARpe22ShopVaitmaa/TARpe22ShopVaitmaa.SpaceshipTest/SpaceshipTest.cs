using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using Xunit;

namespace TARpe22ShopVaitmaa.SpaceshipTest
{
    public class SpaceshipTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            string guid = Guid.NewGuid().ToString();

            SpaceshipDto spaceship = new SpaceshipDto();

            spaceship.Id = Guid.Parse(guid);
            spaceship.Price = 100;
            spaceship.Type = "rocket";
            spaceship.Name = "X ae A 12";
            spaceship.Description = "Description";
            spaceship.FuelType = "Cowfarts";
            spaceship.FuelCapacity = 100;
            spaceship.FuelConsumption = 100;
            spaceship.PassengerCount = 100;
            spaceship.EnginePower = 100;
            spaceship.DoesHaveAutopilot = true;
            spaceship.CrewCount = 100;
            spaceship.CargoWeight = 100;
            spaceship.DoesHaveLifeSupportSystems = true;
            spaceship.BuiltDate = DateTime.Now;
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.MaintenanceCount = 1;
            spaceship.FullTripsCount = 1;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Space Z";
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;
            spaceship.Files = new List<IFormFile>();

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);

            Assert.NotNull(result);
        }
        [Fact]
        public async Task ShouldNot_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            Guid wrongGuid = Guid.Parse(Guid.NewGuid().ToString());
            Guid guid = Guid.Parse("d573fe18-8daa-45cb-8188-ec03e8053e40");

            await Svc<ISpaceshipsServices>().GetAsync(guid);

            Assert.NotEqual(wrongGuid, guid);
        }
        [Fact]
        public async Task Should_GetByIdSpaceship_WhenReturnsNotEqual()
        {
            ISpaceshipsServices svc = Svc<ISpaceshipsServices>();
            Guid guid = Guid.Parse("d573fe18-8daa-45cb-8188-ec03e8053e40");

            SpaceshipDto dto = MockSpaceshipData();
            dto.Id = guid;
            await svc.Create(dto);


            var Spaceship = await svc.GetAsync(guid);
            Assert.Equal(Spaceship.Id, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdSpaceship_WhenDeleteSpaceship()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var spaceship = await Svc<ISpaceshipsServices>().Create(dto);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship.Id);

            Assert.Equal(result, spaceship);
        }
        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("d573fe18-8daa-45cb-8188-ec03e8053e40");

            Spaceship spaceship = new Spaceship();

            SpaceshipDto dto = MockSpaceshipData();

            spaceship.Id = Guid.Parse("d573fe18-8daa-45cb-8188-ec03e8053e40");
            spaceship.Price = 500;
            spaceship.Type = "Saucer";
            spaceship.Name = "Supikauss";
            spaceship.Description = "Sisaldab supi asemel tulnukaid";
            spaceship.FuelType = "Cowfarts";
            spaceship.FuelConsumption = 666;
            spaceship.PassengerCount = 100;
            spaceship.EnginePower = 9000;
            spaceship.DoesHaveAutopilot = true;
            spaceship.CrewCount = 20;
            spaceship.CargoWeight = 60;
            spaceship.DoesHaveLifeSupportSystems = true;
            spaceship.BuiltDate = DateTime.Now.AddYears(2);
            spaceship.LastMaintenance = DateTime.Now;
            spaceship.MaintenanceCount = 2;
            spaceship.FullTripsCount = 1;
            spaceship.MaidenLaunch = DateTime.Now;
            spaceship.Manufacturer = "Space Z";
            spaceship.CreatedAt = DateTime.Now.AddYears(1);
            spaceship.ModifiedAt = DateTime.Now.AddYears(1);

            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            Assert.DoesNotMatch(spaceship.Name, dto.Name);
            Assert.DoesNotMatch(spaceship.CrewCount.ToString(), dto.CrewCount.ToString());
            Assert.Equal(spaceship.EnginePower, dto.EnginePower);
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var spaceship = await Svc<ISpaceshipsServices>().Create(dto);
            var spaceship2 = await Svc<ISpaceshipsServices>().Create(dto);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship2.Id);

            Assert.NotEqual(result, spaceship);
        }

        [Fact]
        public async Task ShouldNot_UpdateSpaceship_WhenNotUpdateData()
        {
            SpaceshipDto dto = MockSpaceshipData();
            var Spaceship = await Svc<ISpaceshipsServices>().Create(dto);

            SpaceshipDto NullUpdate = MockSpaceshipData();
            var result = await Svc<ISpaceshipsServices>().Update(NullUpdate);

            var NullID = NullUpdate.Id;

            Assert.True(result.Id != NullID);
        }

        private SpaceshipDto MockSpaceshipData()
        {
            SpaceshipDto spaceship = new()
            {
                Price = 500,
                Type = "Saucer",
                Name = "Taldrik",
                Description = "Sisaldab supi asemel tulnukaid",
                FuelType = "Cowfarts",
                FuelConsumption = 666,
                PassengerCount = 100,
                EnginePower = 9000,
                DoesHaveAutopilot = true,
                CrewCount = 10,
                CargoWeight = 60,
                DoesHaveLifeSupportSystems = true,
                BuiltDate = DateTime.Now.AddYears(2),
                LastMaintenance = DateTime.Now,
                MaintenanceCount = 2,
                FullTripsCount = 1,
                MaidenLaunch = DateTime.Now,
                Manufacturer = "Space Z",
                CreatedAt = DateTime.Now.AddYears(1),
                ModifiedAt = DateTime.Now.AddYears(1),
            };

            return spaceship;
        }

    }
}
