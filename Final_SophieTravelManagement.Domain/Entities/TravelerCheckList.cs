using Final_SophieTravelManagement.Abstractions.Domain;
using Final_SophieTravelManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_SophieTravelManagement.Domain.Entities
{
    public class TravelerCheckList : AggregateRoot<ValueObjects.TravelerCheckListId>
    {
        public ValueObjects.TravelerCheckListId Id { get; private set; }
        private ValueObjects.TravelerCheckListName _name;
        private ValueObjects.TravelerCheckListDestination _destination;

        private readonly LinkedList<ValueObjects.TravelerItem> _items = new();

        public TravelerCheckList()
        {
        }

        internal TravelerCheckList(
            ValueObjects.TravelerCheckListId id,
            ValueObjects.TravelerCheckListName name,
            ValueObjects.TravelerCheckListDestination destination)
        {
            Id = id;
            _name = name;
            _destination = destination;
        }

        internal TravelerCheckList(
            ValueObjects.TravelerCheckListId id,
            ValueObjects.TravelerCheckListName name,
            ValueObjects.TravelerCheckListDestination destination,
            LinkedList<ValueObjects.TravelerItem> items) : this(id, name, destination)
        {
            _items = items;
        }

        public void AddItem(ValueObjects.TravelerItem item)
        {
            var alreadyExist = _items.Any(i => i.Name == item.Name);

            if (alreadyExist)
                throw new TravelerItemAlreadyExistsException(_name, item.Name);

            _items.AddLast(item);
            AddEvent(new Events.TravelerItemAddedEvent(this, item));
        }

        public void AddItems(IEnumerable<ValueObjects.TravelerItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }

        public void TakeItem(string itemName)
        {
            var item = GetItem(itemName);
            var travelerItem = item with { IsTaken = true };

            _items.Find(item).Value = travelerItem;
            AddEvent(new Events.TravelerItamTakenEvent(this, item));
        }

        private ValueObjects.TravelerItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);

            if (item == null)
                throw new TravelItemNotFoundException(itemName);

            return item;
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new Events.TravelerItemRemovedEvent(this, item));
        }
    }
}
