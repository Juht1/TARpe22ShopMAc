using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;

namespace TARpe22ShopVaitmaa.Core.Dto
{
    public class RealEstateDto
    {
        public Guid Id { get; set; } //unique id
        public EstateType Type { get; set; } //what type of property is being sold
        public string ListingDescription { get; set; } //description that encompasses anything the model doesnt
        public string Address { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get { return (Country + ", " + County + ", " + City + ", " + Address); } }
        public int PostalCode { get; set; }//numeric code denoting the propertys location in the countrys registry
        public int ContactPhone { get; set; } //phone number to contact about the real estate
        public int ContactFax { get; set; } //faxing number to contact about the real estate
        public int SquareMeters { get; set; } //how many square meters does the property have
        public int? Floor { get; set; }//what floor the property takes place
        public int? FloorCount { get; set; } //how many floors does the facility have
        public int Price { get; set; }//how much it costs
        public int? RoomCount { get; set; }
        public int? BedroomCount { get; set; }
        public int? BathroomCount { get; set; }
        public DateTime WhenEstateListedAt { get; set; }
        public bool IsPropertySold { get; set; }
        public bool DoesHaveSwimmingPool { get; set; }
        public DateTime? BuiltAt { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> FileToApiDtos { get; set; } = new List<FileToApiDto>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
