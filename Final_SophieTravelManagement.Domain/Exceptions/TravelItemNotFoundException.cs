using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
public class TravelItemNotFoundException :
    Abstractions.Exceptions.TravelerCheckListException
{
    public string ItemName { get; }

    public TravelItemNotFoundException(string itemName) :
        base($"Traveler item '{itemName}' not found")
        =>ItemName = itemName;
}
}
