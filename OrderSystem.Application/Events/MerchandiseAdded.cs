namespace OrderSystem.Application.Events
{
    using System;

    public class MerchandiseAdded : IEvent
    {
        private MerchandiseAdded(Guid id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public Guid Id { get; }

        public decimal Price { get; }

        public static MerchandiseAdded CreateWith(Guid id, decimal price)
        {
            return new MerchandiseAdded(id, price);
        }
    }
}