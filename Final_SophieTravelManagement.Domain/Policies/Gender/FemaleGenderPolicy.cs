using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies.Gender
{
internal sealed class FemaleGenderPolicy : Policies.ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Consts.Gender.Female;

    public IEnumerable<TravelerItem> GetTravelerItems(PolicyData data)
        => new List<TravelerItem>
        {
            new ("Lipstick",1),
            new ("Powder",1),
            new ("Eyeliner",1),
        };
}
}
