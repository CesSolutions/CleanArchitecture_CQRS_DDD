using Final_SophieTravelManagement.Domain.Entities;
using Final_SophieTravelManagement.Infrastructure.EF.Contexts;
using Final_SophieTravelManagement.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Infrastructure.EF.Services
{
public class TravelerCheckListReader :
    Application.Services.ITravelerCheckListReadService
{
    private readonly DbSet<TravelerCheckListReadModel> _travelerCheckList;

    public TravelerCheckListReader(ReadDbContext context)
        => _travelerCheckList = context.TravelCheckList;

    public Task<bool> ExistsByNameAsync(string name)
        => _travelerCheckList.AnyAsync(x => x.Name == name);
}
}
