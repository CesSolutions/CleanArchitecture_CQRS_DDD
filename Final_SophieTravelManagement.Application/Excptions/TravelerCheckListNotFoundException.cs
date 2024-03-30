using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Excptions
{
    public class TravelerCheckListNotFoundException : Abstractions.Exceptions.TravelerCheckListException
    {
        public Guid Id { get; }
        public TravelerCheckListNotFoundException(Guid id):
            base($"Traveller check list with id '{id}' not found")
        => Id = id;
    }
}
