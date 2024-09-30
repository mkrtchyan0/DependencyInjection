namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Represents a descriptor for a registered service, including its type, implementation, and lifetime.
    /// This class is used to store information about services in a dependency injection container.
    /// </summary>
    public class ServiceDescriptor
    {
        /// <summary>
        /// Gets the type of the service being described.
        /// </summary>
        public Type ServiceType { get; }

        /// <summary>
        /// Gets the type of the implementation for the service.
        /// </summary>
        public Type ImplementationType { get; }

        /// <summary>
        /// Gets or sets the instance of the implementation if it is already created.
        /// This property is internal to allow access only within the same assembly.
        /// </summary>
        public object Implementation { get; internal set; }

        /// <summary>
        /// Gets the lifetime of the service, indicating how long the service instance should be retained.
        /// </summary>
        public ServiceLifeTime LifeTime { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class with the specified implementation instance and lifetime.
        /// </summary>
        /// <param name="implementation">The instance of the service implementation.</param>
        /// <param name="lifetime">The lifetime of the service.</param>
        public ServiceDescriptor(object implementation, ServiceLifeTime lifetime)
        {
            ServiceType = implementation.GetType();
            Implementation = implementation;
            LifeTime = lifetime;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class with the specified service type and lifetime.
        /// </summary>
        /// <param name="serviceType">The type of the service to be described.</param>
        /// <param name="lifeTime">The lifetime of the service.</param>
        public ServiceDescriptor(Type serviceType, ServiceLifeTime lifeTime)
        {
            ServiceType = serviceType;
            LifeTime = lifeTime;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceDescriptor"/> class with the specified service type, implementation type, and lifetime.
        /// </summary>
        /// <param name="serviceType">The type of the service to be described.</param>
        /// <param name="implementationType">The type of the implementation for the service.</param>
        /// <param name="lifeTime">The lifetime of the service.</param>
        public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifeTime lifeTime)
        {
            ServiceType = serviceType;
            ImplementationType = implementationType;
            LifeTime = lifeTime;
        }
    }
}