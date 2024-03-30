using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Application.Excptions
{
    public class TravelerCheckListAlreadyExistsException
        : Abstractions.Exceptions.TravelerCheckListException
    {
        public string Name { get; set; }
        public TravelerCheckListAlreadyExistsException(string name) :
            base($"Traveler Check List with name '{name}' aleardy exists")
        {
            Name = name;
        }
    }
}
