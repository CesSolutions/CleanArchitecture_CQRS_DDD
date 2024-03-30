using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies.Universal
{
internal sealed class BasicPolicy : Policies.ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => true;

    public IEnumerable<TravelerItem> GetTravelerItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Pants", 1),
            new("Socks", 1),
            new("T-Shirt", 1),
            new("Shampoo", 1),
            new("Towel", 1),
            new("Bag pack", 1),
            new("Passport", 1),
            new("Phone Charger", 1),             
        };
}
}
