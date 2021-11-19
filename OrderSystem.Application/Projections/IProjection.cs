namespace OrderSystem.Application.Projections
{
    public interface IProjection
    {
        void When(object @event);
    }
}