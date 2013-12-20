#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog
{
    public static class Guard
    {
        /// <summary>
        /// Determines whether the given argument is not null.
        /// </summary>
        /// <param name="parameter">The value.</param>
        /// <param name="parameterName">The parameter's name.</param>
        public static void IsNotNull(object parameter, string parameterName, string message = null)
        {
            if (parameter.IsNull())
            {
                throw message.IsNullOrEmpty()
                    ? new ArgumentNullException(parameterName)
                    : new ArgumentNullException(parameterName, message);
            }
        }

        /// <summary>
        /// Determines whether the given <see cref="String"/> is null, empty or contains only white spaces.
        /// </summary>
        /// <param name="parameter">The string value.</param>
        /// <param name="parameterName">The parameter's name.</param>
        public static void IsNotNullOrEmpty(string parameter, string parameterName, string message = null)
        {
            if (parameter.IsNullOrEmpty())
            {
                throw message.IsNullOrEmpty()
                    ? new ArgumentException("{0} cannot be null or empty".FormatWith(parameterName))
                    : new ArgumentException(message, parameterName);
            }
        }

        public static void IsNotDefault<TValue>(TValue parameter, string parameterName, string message = null)
        {
            if (parameter.Equals(default(TValue)))
            {
                throw message.IsNullOrEmpty()
                    ? new ArgumentException("{0} cannot be the default value".FormatWith(parameterName))
                    : new ArgumentException(message, parameterName);
            }
        }
    }
}
