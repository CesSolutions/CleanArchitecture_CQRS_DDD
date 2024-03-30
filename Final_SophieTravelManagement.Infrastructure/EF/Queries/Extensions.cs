using Final_SophieTravelManagement.Application.DTO;
using Final_SophieTravelManagement.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Infrastructure.EF.Queries
{
    public static class Extensions
    {
        public static TravelerCheckListDto AsDto(
            this TravelerCheckListReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Destination = new DestinationDto
                {
                    City = readModel.Destination.City,
                    Country = readModel.Destination.Country
                },
                Items = readModel.Items?.Select(x => new TravelerItemDto
                {
                    Name = x.Name,
                    Quantity = x.Quantity,
                    IsTaken = x.IsTaken,
                }),
            };
    }
}
