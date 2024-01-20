namespace Challenges.Infrastructure
{
    internal class ServiceLocator : IServiceLocator
    {
        private readonly Dictionary<Type, Func<IServiceLocator, object>> register = new Dictionary<Type, Func<IServiceLocator, object>>();
        
        public ServiceLocator()
        {
            register.Add(typeof(IServiceLocator), x => this);
        }

        public T Create<T>(Type handlerType)
        {
            return (T)register[handlerType].Invoke(this);
        }

        public T Create<T>()
        {
            return Create<T>(typeof(T));
        }

        public IServiceLocator Register<T>(Func<IServiceLocator, T> createAction)
            where T : class
        {
            register.Add(typeof(T), createAction);
            return this;
        }
    }
}
