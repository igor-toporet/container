using System;
using System.Collections.Generic;
using Munq;

namespace container
{
    public class DefaultContainer : IContainer
    {
        private readonly IocContainer _container;
        public DefaultContainer()
        {
            _container = new IocContainer();
        }
        public bool CanResolve<T>() where T : class
        {
            return _container.CanResolve<T>();
        }
        public T Resolve<T>() where T : class
        {
            // CanResolve would be ideal but it returns false for arbitrary types :(
            //return _container.CanResolve<T>() ? _container.Resolve<T>() : null;
            try
            {
                return _container.Resolve<T>();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public T Resolve<T>(string name) where T : class
        {
            return _container.Resolve<T>(name);
        }
        public bool CanResolve(Type serviceType)
        {
            return _container.CanResolve(serviceType);
        }
        public object Resolve(Type serviceType)
        {
            // CanResolve would be ideal but it returns false for arbitrary types :(
            //return _container.CanResolve(serviceType) ? _container.Resolve(serviceType) : null;
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception)
            {
               return null;
            }
        }
        public object Resolve(Type serviceType, string name)
        {
            return _container.Resolve(name, serviceType);
        }
        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _container.ResolveAll<T>();
        }
        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            return _container.ResolveAll(serviceType);
        }
        public ILifetime Register<T>(Func<T> builder) where T : class
        {
            return new DefaultLifetime(_container.Register(r => builder()));
        }
        public ILifetime Register<T>(string name, Func<T> builder) where T : class
        {
            return new DefaultLifetime(_container.Register(name, r => builder()));
        }
        public ILifetime Register<T>(Func<IDependencyResolver, T> builder) where T : class
        {
            return new DefaultLifetime(_container.Register(r => builder(this)));
        }
        public ILifetime Register<T>(string name, Func<IDependencyResolver, T> builder) where T : class
        {
            return new DefaultLifetime(_container.Register(name, r => builder(this)));
        }
        public void Remove<T>() where T : class
        {
            try
            {
                var registration = _container.GetRegistration<T>();
                if (registration == null) return;
                _container.Remove(registration);
            }
            catch
            {
                // So lame... throws an exception when registration can't be found.
            }
        }
        public void Remove<T>(string name) where T : class
        {
            try
            {
                var registration = _container.GetRegistration<T>(name);
                if (registration == null) return;
                _container.Remove(registration);
            }
            catch
            {
                // So lame... throws an exception when registration can't be found.
            }
        }
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}