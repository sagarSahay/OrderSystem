namespace OrderSystem.Application.Aggregates
{
    using System;
    using Events;
    using Projections;

    public interface IAggregate : IAggregate<Guid>
    {
    }

    public interface IAggregate<out T> : IProjection
    {
        T Id { get; }
        int Version { get; }

        IEvent[] DequeueUncommittedEvents();
    }
}