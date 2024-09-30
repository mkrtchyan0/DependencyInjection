namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Represents a simple Dependency Injection (DI) container for managing service lifetimes and resolving dependencies.
    /// This container allows registering and resolving services, supporting both transient and singleton lifetimes.
    /// </summary>
    public sealed class DiContainer
    {
        /// <summary>
        /// A simple dependency injection container that stores service descriptors for resolving services.
        /// </summary>
        private List<ServiceDescriptor> _serviceDescriptors;
        /// <summary>
        /// Initializes a new instance of the <see cref="DiContainer"/> class with the provided service descriptors.
        /// </summary>
        /// <param name="serviceDescriptors">A list of service descriptors that define how services should be resolved.</param>
        public DiContainer(List<ServiceDescriptor> serviceDescriptors)
        {
            _serviceDescriptors = serviceDescriptors;
        }
        /// <summary>
        /// Resolves and returns an instance of the specified service type from the service container.
        /// Supports both transient and singleton lifetimes. Automatically handles dependency injection
        /// by resolving constructor parameters recursively.
        /// </summary>
        /// <param name="serviceType">The type of the service to be resolved.</param>
        /// <returns>An instance of the requested service.</returns>
        /// <exception cref="Exception">
        /// Thrown if the service type is not registered or if it attempts to instantiate an abstract class or interface.
        /// </exception>
        public object GetService(Type serviceType)
        {
            var descriptor = _serviceDescriptors.SingleOrDefault(x => x.ServiceType == serviceType);

            if (descriptor == null)
            {
                throw new Exception(message: $"Service of type {serviceType.Name} isn't registered");
            }
            if (descriptor.Implementation != null)
            {
                return descriptor.Implementation;
            }

            var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

            if (actualType.IsAbstract || actualType.IsInterface)
            {
                throw new Exception("Cannot instantiate Abstract classes or Interfaces");
            }

            var constructorInfo = actualType.GetConstructors().First();

            var parameters = constructorInfo.GetParameters()
                .Select(x => GetService(x.ParameterType)).ToArray();

            var implementation = Activator.CreateInstance(actualType, parameters);

            if (descriptor.LifeTime == ServiceLifeTime.Singleton)
            {
                descriptor.Implementation = implementation;
            }
            return implementation;
        }
        /// <summary>
        /// Resolves and returns an instance of the specified generic service type from the service container.
        /// Supports dependency injection for the generic type parameter.
        /// </summary>
        /// <typeparam name="T">The type of the service to be resolved.</typeparam>
        /// <returns>An instance of the requested service type.</returns>
        /// <exception cref="Exception">
        /// Thrown if the service type is not registered or if it attempts to instantiate an abstract class or interface.
        /// </exception>
        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }
    }
}
