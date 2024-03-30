using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Respositories
{
    public interface ITravelerCheckListRepository
    {
        Task<Entities.TravelerCheckList> GetAsync(ValueObjects.TravelerCheckListId id);
        Task AddAsync(Entities.TravelerCheckList travelerCheckList);
        Task UpdateAsync(Entities.TravelerCheckList travelerCheckList);
        Task DeleteAsync(Entities.TravelerCheckList travelerCheckList);
    }
}
