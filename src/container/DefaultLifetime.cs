using Munq;

namespace container
{
    public class MunqLifetime : ILifetime
    {
        private readonly IRegistration _registration;
        public MunqLifetime(IRegistration registration)
        {
            _registration = registration;
        }
        public void Permanent()
        {
            _registration.AsContainerSingleton();
        }
        public void Thread()
        {
            _registration.AsThreadSingleton();
        }
        public void Request()
        {
            _registration.AsRequestSingleton();
        }
        public void Session()
        {
            _registration.AsSessionSingleton();
        }
        public void AlwaysNew()
        {
            _registration.AsAlwaysNew();
        }
    }
}