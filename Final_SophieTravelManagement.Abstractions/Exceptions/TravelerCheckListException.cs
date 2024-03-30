using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Abstractions.Exceptions
{
    public abstract class TravelerCheckListException : Exception
    {
        public TravelerCheckListException(string message) : base(message)
        {
        }
    }
}
