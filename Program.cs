using TryingStuffOut.DependencyInjection;

namespace TryingStuffOut
{
    /// <summary>
    /// The entry point of the application that demonstrates the usage of the dependency injection container.
    /// It registers services, generates the container, and retrieves service instances.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main method that initializes the dependency injection container,
        /// registers services, and retrieves and uses the services.
        /// </summary>
        /// <param name="args">The command-line arguments for the application.</param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Demonstrates the setup and usage of a simple dependency injection (DI) container.
            /// It registers services with their respective lifetimes, generates a container,
            /// retrieves service instances, and invokes a method to display output.
            /// </summary>
            var services = new DiServiceCollection();

            // Registers the <see cref="ISomeService"/> interface with <see cref="SomeServiceOne"/> implementation as a transient service.
            services.RegisterTransient<ISomeService, SomeServiceOne>();

            // Registers the <see cref="IRandomGuidProvider"/> interface with <see cref="RandomGuidProvider"/> implementation as a singleton service.
            services.RegisterSingleton<IRandomGuidProvider, RandomGuidProvider>();

            // Generates a new instance of the <see cref="DiContainer"/> to resolve dependencies.
            var container = services.GenerateContainer();

            // Retrieves an instance of <see cref="ISomeService"/> from the container.
            var serviceFirst = container.GetService<ISomeService>();

            // Retrieves another instance of <see cref="ISomeService"/> from the container. 
            // This will be a new instance since <see cref="ISomeService"/> is registered as transient.
            var serviceSecond = container.GetService<ISomeService>();

            // Calls the PrintSomething method on the first service instance to display a randomly generated GUID.
            serviceFirst.PrintSomething();
            serviceSecond.PrintSomething();
        }
    }

}
