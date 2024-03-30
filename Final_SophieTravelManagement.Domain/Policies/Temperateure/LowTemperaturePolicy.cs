using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies.Temperateure
{
internal sealed class LowTemperaturePolicy : Policies.ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature < 10D;

    public IEnumerable<TravelerItem> GetTravelerItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Winter Hat", 1),
            new("Scarf", 1),
            new("Gloves", 1),
            new("Hoodie", 1),
            new("Warm Jacket", 1),
        };     
}
}
