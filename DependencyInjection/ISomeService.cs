using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryingStuffOut.DependencyInjection
{
    /// <summary>
    /// Defines a contract for a service that can print or display some information.
    /// </summary>
    public interface ISomeService
    {
        /// <summary>
        /// Prints or outputs some information when implemented.
        /// </summary>
        void PrintSomething();
    }
}
