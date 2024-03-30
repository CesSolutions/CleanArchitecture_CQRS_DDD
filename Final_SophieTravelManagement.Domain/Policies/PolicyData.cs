using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies
{
    public record PolicyData(
        ValueObjects.TravelDays Days,
        Consts.Gender Gender,
        ValueObjects.Temperature Temperature,
        ValueObjects.TravelerCheckListDestination Destination)
    {
    }
}
