using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Commands
{
public record AddTravelerItem(
    Guid TravelerCheckListId, string Name, uint Quantity) :
    Abstractions.Commands.ICommand;
}
