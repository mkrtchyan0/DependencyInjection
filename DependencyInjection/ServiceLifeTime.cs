using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Defines the lifetime of a service within a dependency injection container.
    /// </summary>
    public enum ServiceLifeTime
    {
        /// <summary>
        /// Indicates that a single instance of the service will be created and shared throughout the application's lifetime.
        /// </summary>
        Singleton,

        /// <summary>
        /// Indicates that a new instance of the service will be created each time it is requested.
        /// </summary>
        Transient
    }
}
