using System;

namespace container
{
    public interface IDependencyRegistrar : IDisposable
    {
        ILifetime Register<T>(Func<T> builder) where T : class;
        ILifetime Register<T>(string name, Func<T> builder) where T : class;
        ILifetime Register<T>(Func<IDependencyResolver, T> builder) where T : class;
        ILifetime Register<T>(string name, Func<IDependencyResolver, T> builder) where T : class;
        void Remove<T>() where T : class;
        void Remove<T>(string name) where T : class;
    }
}