using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
    public class TravelerCheckListIdException : 
        Abstractions.Exceptions.TravelerCheckListException
    {
        public TravelerCheckListIdException() : 
            base("Traveler CheckList Id cannot be empty.")
        {
        }
    }
}
