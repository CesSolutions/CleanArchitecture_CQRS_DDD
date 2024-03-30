using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
    public class InvalidTemperatureException :
        Abstractions.Exceptions.TravelerCheckListException
    {
        public double Value { get; }

        public InvalidTemperatureException(double value) :
            base($"Value '{value}' is invalid temprature")
        => Value = value;
    }
}
