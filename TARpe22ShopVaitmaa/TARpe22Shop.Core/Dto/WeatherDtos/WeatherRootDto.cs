using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TARpe22ShopVaitmaa.Core.Dto.WeatherDtos
{
    public class WeatherRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
    }
}
