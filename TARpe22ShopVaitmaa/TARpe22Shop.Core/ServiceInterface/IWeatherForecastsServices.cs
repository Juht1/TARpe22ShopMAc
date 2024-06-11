using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopVaitmaa.Core.Dto.WeatherDtos;

namespace TARpe22ShopVaitmaa.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        public Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
        public Task<OpenWeatherResultDto> OpenWeatherDetail(OpenWeatherResultDto dto);
    }
}