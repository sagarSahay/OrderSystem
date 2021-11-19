namespace OrderSystem.Application.Aggregates
{
    using System;
    using System.Collections.Generic;
    using Events;

    public class OrderAggregate : Aggregate<Guid>
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public decimal Total { get; private set; }
        public OrderStatus Status { get; private set; }
        public List<TicketItem> Tickets { get; private set; }

        public override void When(object @event)
        {
            switch (@event)
            {
                case OrderInitiated orderInitiated:
                    Apply(orderInitiated);
                    break;
                case TicketAdded ticketAdded:
                    Apply(ticketAdded);
                    break;
            }
        }

        private void Apply(OrderInitiated @event)
        {
            Version++;
            Id = @event.OrderId;
            Status = OrderStatus.InProgress;
            Tickets = new List<TicketItem>();
            CustomerId = @event.CustomerId;
        }

        private void Apply(TicketAdded @event)
        {
            Version++;
            Tickets.Add(@event.TicketItem);
            Total += @event.TicketItem.Price;
        }
    }
}