using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Queries
{
public class SearchTravelerChekcList :
    Abstractions.Queries.IQuery<DTO.TravelerCheckListDto>
{
    public string SearchPhrase { get; set; }
}
}
