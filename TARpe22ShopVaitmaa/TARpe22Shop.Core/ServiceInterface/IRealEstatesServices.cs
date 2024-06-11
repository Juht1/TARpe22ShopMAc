using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;

namespace TARpe22ShopVaitmaa.Core.ServiceInterface
{
    public interface IRealEstatesServices
    {
        Task<RealEstate> Create(RealEstateDto dto);
        Task<RealEstate> GetAsync(Guid id);
        Task<RealEstate> Delete(Guid id);
        Task<RealEstate> Update(RealEstateDto dto);
    }
}
