using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
    public class TravelerCheckListNameException :
        Abstractions.Exceptions.TravelerCheckListException
    {
        public TravelerCheckListNameException() :
            base("Traveler CheckList Name cannot be empty.")
        {
        }
    }
}
