using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Exceptions
{
    public class TravelerItemNameException :
        Abstractions.Exceptions.TravelerCheckListException
    {
        public TravelerItemNameException() :
            base("Traveler Item name cannot be empty.")
        {
        }
    }
}
