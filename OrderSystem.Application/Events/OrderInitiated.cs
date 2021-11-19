namespace OrderSystem.Application.Events
{
    using System;

    public class OrderInitiated : IEvent
    {
        private OrderInitiated(Guid orderId, Guid customerId)
        {
            OrderId = orderId;
            CustomerId = customerId;
        }

        public Guid OrderId { get; }
        public Guid CustomerId { get; }

        public static OrderInitiated CreateWith(Guid orderId, Guid customerId)
        {
            return new OrderInitiated(orderId, customerId);
        }
    }
}