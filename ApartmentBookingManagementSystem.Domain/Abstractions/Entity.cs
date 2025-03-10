namespace ApartmentBookingManagementSystem.Domain.Abstractions
{
    public abstract class Entity
    {
        #region Fields

        private readonly List<IDomainEvent> _domainEvents = new();

        #endregion Fields

        #region Protected Constructors

        protected Entity(Guid id)
        {
            id = Id;
        }

        #endregion Protected Constructors

        #region Properties

        public Guid Id { get; init; }

        #endregion Properties

        #region Public Methods

        public IReadOnlyList<IDomainEvent> GetDomainEvent()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        #endregion Public Methods
    }
}