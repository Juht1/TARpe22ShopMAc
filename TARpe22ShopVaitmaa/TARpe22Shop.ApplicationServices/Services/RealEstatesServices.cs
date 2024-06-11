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
    public class RealEstatesServices : IRealEstatesServices
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly IFilesServices _filesServices;
        public RealEstatesServices
            (
            TARpe22ShopVaitmaaContext context,
            IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<RealEstate> GetAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<RealEstate> Create(RealEstateDto dto)
        {
            RealEstate realEstate = new();

            //var realEstateProps = typeof(RealEstate).GetProperties();
            //var realEstateDtoProps = typeof(RealEstateDto).GetProperties();
            //for (int i = 0; i < realEstateProps.Length; i++)
            //{
            //    var realEstateProp = realEstateProps[i];
            //    for (int j = 0; j < realEstateDtoProps.Length; j++)
            //    {
            //        var realEstateDtoProp = realEstateDtoProps[j];
            //        if (realEstateProp.Name == realEstateDtoProp.Name)
            //        {
            //            realEstateProp.SetValue(realEstate, realEstateDtoProp.GetValue(dto));
            //        }
            //    }
            //}
            realEstate.Id = Guid.NewGuid();
            realEstate.Type = dto.Type;
            realEstate.ListingDescription = dto.ListingDescription;
            realEstate.Address = dto.Address;
            realEstate.Country = dto.Country;
            realEstate.County = dto.County;
            realEstate.City = dto.City;
            realEstate.PostalCode = dto.PostalCode;
            realEstate.ContactPhone = dto.ContactPhone;
            realEstate.ContactFax = dto.ContactFax;
            realEstate.SquareMeters = dto.SquareMeters;
            realEstate.Floor = dto.Floor;
            realEstate.FloorCount = dto.FloorCount;
            realEstate.Price = dto.Price;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.BedroomCount = dto.BedroomCount;
            realEstate.BathroomCount = dto.BathroomCount;
            realEstate.WhenEstateListedAt = dto.WhenEstateListedAt;
            realEstate.IsPropertySold = dto.IsPropertySold;
            realEstate.DoesHaveSwimmingPool = dto.DoesHaveSwimmingPool;
            realEstate.BuiltAt = dto.BuiltAt;

            realEstate.CreatedAt = DateTime.Now;
            realEstate.ModifiedAt = DateTime.Now;
            _filesServices.FilesToApi(dto, realEstate);

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;

            
        }
        public async Task<RealEstate> Delete(Guid id)
        {
            var realEstateId = await _context.RealEstates
                .Include(x => x.FilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FilesToApi
                .Where(x => x.RealEstateId == id)
                .Select(y => new FileToApiDto
                {
                    Id = y.Id,
                    RealEstateId = y.RealEstateId,
                    ExistingFilePath = y.ExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.RealEstates.Remove(realEstateId);
            await _context.SaveChangesAsync();
            return realEstateId;
        }

        public async Task<RealEstate> Update(RealEstateDto dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = dto.Id;
            realEstate.Type = dto.Type;
            realEstate.ListingDescription = dto.ListingDescription;
            realEstate.Address = dto.Address;
            realEstate.City = dto.City;
            realEstate.PostalCode = dto.PostalCode;
            realEstate.ContactPhone = dto.ContactPhone;
            realEstate.ContactFax = dto.ContactFax;
            realEstate.SquareMeters = dto.SquareMeters;
            realEstate.Floor = dto.Floor;
            realEstate.FloorCount = dto.FloorCount;
            realEstate.Price = dto.Price;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.BedroomCount = dto.BedroomCount;
            realEstate.BathroomCount = dto.BathroomCount;
            realEstate.WhenEstateListedAt = dto.WhenEstateListedAt;
            realEstate.IsPropertySold = dto.IsPropertySold;
            realEstate.DoesHaveSwimmingPool = dto.DoesHaveSwimmingPool;
            realEstate.BuiltAt = dto.BuiltAt;
            _context.RealEstates.Update(realEstate);
            await _context.SaveChangesAsync();
            return realEstate;
        }
    }
}
