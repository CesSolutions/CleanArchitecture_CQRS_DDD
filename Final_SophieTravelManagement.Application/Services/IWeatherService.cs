using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Services
{
public interface IWeatherService
{
    Task<DTO.External.WeatherDto> GetWeatherAsync(
        Domain.ValueObjects.TravelerCheckListDestination localization);
}
}
