using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teleopti.PizzaExperts.Framework.Utility.Validation
{
    /// <summary>
    /// Argument Validation
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// Validate  the condition
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        public static void Validate(bool condition, string name)
        {
            if (!condition)
            {
                throw new ArgumentException("Invalid argument", name);
            }
        }

        /// <summary>
        /// Validate the condition
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public static void Validate(bool condition, string name, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message, name);
            }
        }

        /// <summary>
        /// Throw If Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfNull<T>(T value, string name) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        /// <summary>
        /// Throw If Null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public static void ThrowIfNull<T>(T value, string name, string message) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(name, message);
            }
        }

        /// <summary>
        /// Throw If Null Or Empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        public static void ThrowIfNullOrEmpty(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Argument must be a non empty string", name);
            }
        }

        /// <summary>
        /// Throw If Null Or Empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public static void ThrowIfNullOrEmpty(string value, string name, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message, name);
            }
        }
    }
}
