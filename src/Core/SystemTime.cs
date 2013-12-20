#region Libraries
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text; 
#endregion

namespace Blog
{
    /// <summary>
    /// Class that access the system current date and time.
    /// <remarks>This class must be used instead of <see cref="DateTimeOffset"/> becuase it makes unit testing of time-sensitive code far easier.</remarks>
    /// </summary>
    public static class SystemTime
    {
        private static Func<DateTimeOffset> now = () => DateTimeOffset.UtcNow;

        /// <summary>
        /// Returns the current date and time.
        /// </summary>
        public static DateTimeOffset Now
        {
            [DebuggerStepThrough]
            get { return now(); }
        }


        /// <summary>
        /// Sets the current date and time.
        /// </summary>
        /// <param name="dateTime">The current date and time.</param>
        public static void SetNow(DateTime dateTime)
        {
            SetNow(() => dateTime);
        }

        /// <summary>
        /// Sets how current date and time is resolved.
        /// </summary>
        /// <param name="dateTimeResolver">The current date and time resolver.</param>
        public static void SetNow(Func<DateTimeOffset> dateTimeResolver)
        {
            Guard.IsNotNull(dateTimeResolver, "dateTimeResolver");

            now = dateTimeResolver;
        }

        /// <summary>
        /// Resets the current date and time value to its default.
        /// <remarks>(The default value is DateTimeOffset.UtcNow)</remarks>
        /// </summary>
        public static void ResetNow()
        {
            now = () => DateTimeOffset.UtcNow;
        }
    }
}
