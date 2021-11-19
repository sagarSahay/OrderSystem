namespace OrderSystem.Application.Events
{
    using System;

    public class TicketAdded : IEvent
    {
        private TicketAdded(Guid orderId, TicketItem ticketItem)
        {
            OrderId = orderId;
            TicketItem = ticketItem;
        }

        public TicketItem TicketItem { get; }
        public Guid OrderId { get; }

        public static TicketAdded CreateWith(Guid orderId, TicketItem ticketItem)
        {
            return new TicketAdded(orderId, ticketItem);
        }
    }


    public class TicketItem
    {
        private TicketItem(Guid id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public Guid Id { get; }
        public decimal Price { get; }

        public static TicketItem CreateNew(Guid id, decimal price)
        {
            return new TicketItem(id, price);
        }
    }
}