using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Queries
{
public class GetTravelerChekcList : 
        Abstractions.Queries.IQuery<DTO.TravelerCheckListDto>
{
    public Guid Id { get; set; }
}
}
