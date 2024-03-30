using Final_SophieTravelManagement.Application.Queries;
using Final_SophieTravelManagement.Domain.Respositories;
using Final_SophieTravelManagement.Infrastructure.EF.Contexts;
using Final_SophieTravelManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Final_SophieTravelManagement.Infrastructure.EF.Queries.Handlers
{
    public class GetTravelerChekcListHandler :
        Abstractions.Queries.IQueryHandler<GetTravelerChekcList,
            Application.DTO.TravelerCheckListDto>
    {
        private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

        public GetTravelerChekcListHandler(ReadDbContext contex)
            => _travelerCheckList = contex.TravelCheckList;

        public async Task<Application.DTO.TravelerCheckListDto>
                HandleAsync(GetTravelerChekcList query)
            => await _travelerCheckList
            .Include(x => x.Items)
            .Where(x => x.Id == query.Id)
            .Select(x => x.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
}
