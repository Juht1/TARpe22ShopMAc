using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Domain;
using TARpe22ShopVaitmaa.Core.Dto;

namespace TARpe22ShopVaitmaa.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> Update(CarDto dto);
        Task<Car> Delete(Guid id);
        Task<Car> GetAsync(Guid id);
    }
}
