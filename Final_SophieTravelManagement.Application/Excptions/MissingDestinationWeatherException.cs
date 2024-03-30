using Final_SophieTravelManagement.Abstractions.Exceptions;
using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Excptions
{
    public class MissingDestinationWeatherException : TravelerCheckListException
    {
        public TravelerCheckListDestination Destination { get; }

        public MissingDestinationWeatherException(TravelerCheckListDestination destination):
            base($"Couldn't fetch weather data for '{destination.country}'/{destination.city}")
        {
            Destination = destination;
        }
    }
}
