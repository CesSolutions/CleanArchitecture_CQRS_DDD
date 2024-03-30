using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Policies.Gender
{
internal sealed class MaleGenderPolicy : Policies.ITravelerItemsPolicy
{
    public bool IsApplicable(PolicyData data)
        => data.Gender is Consts.Gender.Male;
    public IEnumerable<TravelerItem> GetTravelerItems(PolicyData data)
        => new List<TravelerItem>
        {
            new("Laptop",1),
            new("Drink",10),
            new("Book",1),
        };
}
}
