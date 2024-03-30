using Final_SophieTravelManagement.Application.Excptions;
using Final_SophieTravelManagement.Domain.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Commands.Handlers
{
internal sealed class TakeItemHandler :
    Abstractions.Commands.ICommandHandler<TakeItem>
{
    private readonly ITravelerCheckListRepository _repository;
    public TakeItemHandler(ITravelerCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(TakeItem command)
    {
        var travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);

        if (travelerCheckingList == null)
            throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);

        travelerCheckingList.RemoveItem(command.Name);

        await _repository.UpdateAsync(travelerCheckingList);
    }
}
}
