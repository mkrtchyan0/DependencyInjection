namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// A collection for registering services and their lifetimes (Singleton or Transient).
    /// Provides methods to register services and generate a <see cref="DiContainer"/> for resolving dependencies.
    /// </summary>
    public class DiServiceCollection
    {
        /// <summary>
        /// A private list that stores service descriptors representing the registered services and their lifetimes.
        /// </summary>
        private List<ServiceDescriptor> _serviceDescriptors = new List<ServiceDescriptor>();
        /// <summary>
        /// Registers a service as a singleton, meaning the same instance will be used throughout the application's lifetime.
        /// </summary>
        /// <typeparam name="TService">The type of the service to be registered.</typeparam>
        public void RegisterSingleton<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singleton));
        }
        /// <summary>
        /// Registers a service with an implementation type as a singleton. 
        /// The same instance of the implementation will be used for the service throughout the application's lifetime.
        /// </summary>
        /// <typeparam name="TService">The type of the service interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the service implementation.</typeparam>
        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singleton));
        }
        /// <summary>
        /// Registers a service as transient, meaning a new instance will be created every time the service is requested.
        /// </summary>
        /// <typeparam name="TService">The type of the service to be registered.</typeparam>
        public void RegisterTransient<TService>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
        }
        /// <summary>
        /// Registers a service with an implementation type as transient. 
        /// A new instance of the implementation will be created every time the service is requested.
        /// </summary>
        /// <typeparam name="TService">The type of the service interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the service implementation.</typeparam>
        public void RegisterTransient<TService, TImplementation>()
        {
            _serviceDescriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
        }
        /// <summary>
        /// Generates a new instance of the <see cref="DiContainer"/> using the registered service descriptors.
        /// </summary>
        /// <returns>A <see cref="DiContainer"/> that can resolve the registered services.</returns>
        public DiContainer GenerateContainer()
        {
            return new DiContainer(_serviceDescriptors);
        }
    }
}
