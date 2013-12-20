using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Blog
{
    /// <summary>
    /// Static class which contains extension methods of <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Executes the provided action for each item.
        /// </summary>
        /// <typeparam name="T">A generic parameter that specifies the type of the items.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="action">The action.</param>
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> instance, Action<T> action)
        {
            Guard.IsNotNull(action, "action");
            if (instance != null)
            {
                foreach (T item in instance)
                {
                    action(item);
                }
            }
        }

        [DebuggerStepThrough]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source.IsNull() || !source.Any();
        }
    }
}
