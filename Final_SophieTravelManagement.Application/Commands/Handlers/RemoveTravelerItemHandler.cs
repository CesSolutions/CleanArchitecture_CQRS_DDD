using Final_SophieTravelManagement.Application.Excptions;
using Final_SophieTravelManagement.Domain.Respositories;
using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Commands.Handlers
{
internal sealed class RemoveTravelerItemHandler :
    Abstractions.Commands.ICommandHandler<RemoveTravelerItem>
{
    private readonly ITravelerCheckListRepository _repository;
    public RemoveTravelerItemHandler(ITravelerCheckListRepository repository)
        => _repository = repository;
        
    public async Task HandleAsync(RemoveTravelerItem command)
    {
        var travelerChekingList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerChekingList == null)
            throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);

        travelerChekingList.RemoveItem(command.Name);

        await _repository.UpdateAsync(travelerChekingList);
    }
}
}
