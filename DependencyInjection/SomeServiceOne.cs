using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Represents a service that implements <see cref="ISomeService"/>.
    /// This service is responsible for printing a randomly generated GUID provided by an <see cref="IRandomGuidProvider"/>.
    /// </summary>
    public class SomeServiceOne : ISomeService
    {
        /// <summary>
        /// A private read-only field that holds an instance of <see cref="IRandomGuidProvider"/>.
        /// This provider is used to generate and retrieve a random GUID for the service.
        /// </summary>
        private readonly IRandomGuidProvider _randomGuidProvider;
        /// <summary>
        /// Initializes a new instance of the <see cref="SomeServiceOne"/> class with the specified <see cref="IRandomGuidProvider"/>.
        /// </summary>
        /// <param name="randomGuidProvider">An instance of <see cref="IRandomGuidProvider"/> used to retrieve a random GUID.</param>
        public SomeServiceOne(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }
        /// <summary>
        /// Prints the randomly generated GUID to the console.
        /// </summary>
        public void PrintSomething()
        {
            Console.WriteLine(_randomGuidProvider.RandomGuid);
        }
    }
}
