using Final_SophieTravelManagement.Domain.Consts;
using Final_SophieTravelManagement.Domain.Entities;
using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Factories
{
public sealed class TravelerCheckListFactory : ITravelerCheckListFactory
{
    // DI ITravelerItemsPolicy
    private readonly IEnumerable<Policies.ITravelerItemsPolicy> _policies;

    public TravelerCheckListFactory(IEnumerable<Policies.ITravelerItemsPolicy> policies)
    {
        _policies = policies;
    }

    public TravelerCheckList Create(TravelerCheckListId id,
        TravelerCheckListName name, TravelerCheckListDestination destination)
        => new(id, name, destination);

    public TravelerCheckList CreateWithDefaultItems(
        TravelerCheckListId id, TravelerCheckListName name,
        TravelDays days, Gender gender, Temperature temperature, 
        TravelerCheckListDestination destination)
    {
        var data = new Policies.PolicyData(days, gender, temperature, destination);
        var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

        var items = applicablePolicies.SelectMany(p => p.GetTravelerItems(data));
        var travelerCheckList = Create(id, name, destination);

        travelerCheckList.AddItems(items);

        return travelerCheckList;
    }
}
}
