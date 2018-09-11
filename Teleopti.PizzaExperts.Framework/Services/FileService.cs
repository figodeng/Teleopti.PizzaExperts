using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Services
{
    /// <summary>
    /// File Services
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Read File Infos
        /// </summary>
        /// <param name="filePath">filePath</param>
        /// <returns></returns>
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath)) return string.Empty;

            string text = File.ReadAllText(filePath);

            return text;
        }
    }
}
