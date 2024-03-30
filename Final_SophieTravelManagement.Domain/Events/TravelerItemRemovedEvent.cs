using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Events
{
    partial record TravelerItemRemovedEvent(
        Entities.TravelerCheckList TravelerCheckList,
        ValueObjects.TravelerItem TravelerItem) : Abstractions.Domain.IDomainEvent
    {
    }
}
