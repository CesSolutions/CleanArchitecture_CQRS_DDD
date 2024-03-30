using Final_SophieTravelManagement.Application.Excptions;
using Final_SophieTravelManagement.Domain.Respositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Commands.Handlers
{
internal sealed class RemoveTravelerCheckListHandler :
    Abstractions.Commands.ICommandHandler<RemoveTravelerCheckList>
{
    private readonly ITravelerCheckListRepository _repository;
    public RemoveTravelerCheckListHandler(ITravelerCheckListRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveTravelerCheckList command)
    {
        var TraverlerCheckList = await _repository.GetAsync(command.Id);

        if (TraverlerCheckList == null)
            throw new TravelerCheckListNotFoundException(command.Id);

        await _repository.DeleteAsync(TraverlerCheckList);
    }
}
}
