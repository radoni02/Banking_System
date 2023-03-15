using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Core.Domain.Primitives
{
    internal abstract class AggregateRoot : Entity 
    {
        protected AggregateRoot(Guid id) : base(id)
        {
        }
        public int Version { get; protected set; }
        private bool _versionIncremented;
        public IEnumerable<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();
        protected void AddEvent(IDomainEvent @event)
        {
            if (!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;
            }

            _events.Add(@event);
        }
        public void ClearEvents() => _events.Clear();
        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }



    }

}
