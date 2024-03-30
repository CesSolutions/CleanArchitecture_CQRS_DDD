using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
    public class InvalidTravelDaysException :
        Abstractions.Exceptions.TravelerCheckListException
    {
        public ushort Value { get; }

        public InvalidTravelDaysException(ushort value) :
            base($"Value '{value}' is invalid days")
        => Value = value;
    }
}
