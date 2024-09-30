using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Provides an interface for generating and retrieving a random GUID.
    /// </summary>
    public interface IRandomGuidProvider
    {
        /// <summary>
        /// Gets a randomly generated GUID.
        /// </summary>
        Guid RandomGuid { get; }
    }
    /// <summary>
    /// A concrete implementation of <see cref="IRandomGuidProvider"/> that generates a random GUID upon instantiation.
    /// </summary>
    public class RandomGuidProvider : IRandomGuidProvider
    {
        /// <summary>
        /// Gets a randomly generated GUID. The GUID is generated when the instance is created and remains constant.
        /// </summary>
        public Guid RandomGuid { get; } = Guid.NewGuid();
    }
}
