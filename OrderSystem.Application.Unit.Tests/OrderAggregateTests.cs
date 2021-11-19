namespace OrderSystem.Application.Unit.Tests
{
    using System;
    using Aggregates;
    using Events;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    public class OrderAggregateTests
    {
        [Test]
        public void Aggregation_with_when_should_get_current_state()
        {
            var customerId = Guid.NewGuid();
            var orderId = Guid.NewGuid();
            var orderInitiated = OrderInitiated.CreateWith(orderId, customerId);

            var ticketItem = TicketItem.CreateNew(Guid.NewGuid(), 10m);

            var ticketAdded = TicketAdded.CreateWith(orderInitiated.OrderId, ticketItem);

            var events = new object[] {orderInitiated, ticketAdded};

            var orderAggregate = new OrderAggregate();

            foreach (var @event in events) orderAggregate.When(@event);

            orderAggregate.Id.Should().Be(orderId);
            orderAggregate.Status.Should().Be(OrderStatus.InProgress);
            orderAggregate.Tickets.Count.Should().Be(1);
            orderAggregate.Total.Should().Be(ticketItem.Price);
        }
    }
}