﻿using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies.Temperateure
{
internal sealed class HighTemperaturePolicy : Policies.ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Temperature > 25D;

    public IEnumerable<TravelerItem> GetTravelerItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Hat", 1),
            new("Sunglasses", 1),
            new("Cream with UV filter", 1),
        };
}
}
