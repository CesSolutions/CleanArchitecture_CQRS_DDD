using Final_SophieTravelManagement.Domain.Respositories;
using Final_SophieTravelManagement.Domain.ValueObjects;
using Final_SophieTravelManagement.Application.Excptions;

namespace Final_SophieTravelManagement.Application.Commands.Handlers
{
    internal sealed class AddTravelerItemHandler :
            Abstractions.Commands.ICommandHandler<AddTravelerItem>
    {
        private readonly ITravelerCheckListRepository _repository;
        public AddTravelerItemHandler(ITravelerCheckListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(AddTravelerItem command)
        {
            var travelerCheckingList = await _repository.GetAsync(command.TravelerCheckListId);

            if (travelerCheckingList == null)
                throw new TravelerCheckListNotFoundException(command.TravelerCheckListId);

            var travelerItem = new TravelerItem(command.Name, command.Quantity);
            travelerCheckingList.AddItem(travelerItem);

            await _repository.UpdateAsync(travelerCheckingList);
        }
    }
}
