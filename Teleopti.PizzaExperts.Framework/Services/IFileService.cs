using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Services
{
    /// <summary>
    /// File Services
    /// </summary>
    public interface IFileService:IDependency
    {
        /// <summary>
        /// Read File infos
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <returns></returns>
        string ReadFile(string filePath);
    }
}
