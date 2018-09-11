using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework
{
    /// <summary>
    /// Base interface for services that are instantiated per unit of work (i.e. web request).
    /// </summary>
    public interface IDependency
    {
    }

    /// <summary>
    /// Base interface for services that are instantiated per applocation.
    /// </summary>
    public interface ISingletonDependency : IDependency
    {
    }

    /// <summary>
    /// Base interface for services that are instantiated per usage.
    /// </summary>
    public interface ITransientDependency : IDependency
    {
    }
}
