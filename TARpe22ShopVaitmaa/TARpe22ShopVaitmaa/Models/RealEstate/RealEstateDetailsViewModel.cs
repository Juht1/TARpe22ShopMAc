﻿using TARpe22ShopVaitmaa.Core.Domain;

namespace TARpe22ShopVaitmaa.Models.RealEstate
{
    public class RealEstateDetailsViewModel
    {
        public Guid Id { get; set; } //unique id
        public EstateType Type { get; set; } //what type of property is being sold
        public string ListingDescription { get; set; } //description that encompasses anything the model doesnt
        public string Address { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
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
        public List<FileToApiViewModel> FileToApiViewModels { get; set; } = new List<FileToApiViewModel>();

        //db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
