using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Abstractions.Queries
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery :
        class, Abstractions.Queries.IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
