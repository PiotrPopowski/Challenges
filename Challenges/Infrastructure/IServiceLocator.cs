namespace Challenges.Infrastructure
{
    public interface IServiceLocator
    {
        T Create<T>(Type handlerType);
        T Create<T>();
    }
}