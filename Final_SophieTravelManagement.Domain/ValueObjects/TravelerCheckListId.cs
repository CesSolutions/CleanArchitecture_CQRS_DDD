﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.ValueObjects
{
    public record TravelerCheckListId
    {
        public Guid Value { get; }

        public TravelerCheckListId(Guid value)
        {
            if (value == null)
                throw new Exceptions.TravelerCheckListIdException();

            Value = value;
        }

        public static implicit operator Guid(TravelerCheckListId id)
            => id.Value;

        public static implicit operator TravelerCheckListId(Guid id)
            => new(id);
    }
}
