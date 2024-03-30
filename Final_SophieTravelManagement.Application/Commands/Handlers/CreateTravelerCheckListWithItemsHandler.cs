using Final_SophieTravelManagement.Application.Excptions;
using Final_SophieTravelManagement.Application.Services;
using Final_SophieTravelManagement.Domain.Factories;
using Final_SophieTravelManagement.Domain.Respositories;
using Final_SophieTravelManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Commands.Handlers
{
    internal sealed class CreateTravelerCheckListWithItemsHandler :
        Abstractions.Commands.ICommandHandler<CreateTravelerCheckListWithItems>
    {
        private readonly ITravelerCheckListRepository _repository;
        private readonly ITravelerCheckListFactory _factory;
        private readonly IWeatherService _weatherService;
        private readonly ITravelerCheckListReadService _readService;

        public CreateTravelerCheckListWithItemsHandler(
            ITravelerCheckListRepository repository,
            ITravelerCheckListFactory factory,
            IWeatherService weatherService,
            ITravelerCheckListReadService readService)
        {
            _repository = repository;
            _factory = factory;
            _weatherService = weatherService;
            _readService = readService;
        }

        public async Task HandleAsync(CreateTravelerCheckListWithItems command)
        {
            // Assign all proeprties of command to => id, name,...
            var (id, name, days, gender, destinationWriteModel) = command;

            if (await _readService.ExistsByNameAsync(name))
                throw new TravelerCheckListAlreadyExistsException(name);

            var destination = new TravelerCheckListDestination
                (destinationWriteModel.City,
                destinationWriteModel.Country);

            // Call external service to get temp. according to location
            var weather = await _weatherService.GetWeatherAsync(destination);

            if (weather == null)
                throw new MissingDestinationWeatherException(destination);

            // Use factory to create new instance by considering domainpolicies
            var travelerCheckList =
                    _factory.CreateWithDefaultItems(
                        id, name, days, gender, weather.Temperature, destination);

            await _repository.AddAsync(travelerCheckList);
        }
    }
}
