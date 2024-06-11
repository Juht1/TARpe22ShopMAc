using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Dto;

namespace TARpe22ShopVaitmaa.Core.ServiceInterface
{
    public interface IEmailService
    {
        void SendEmail(EmailDto dto);
    }
}
