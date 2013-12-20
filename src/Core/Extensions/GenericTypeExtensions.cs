#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog
{
    /// <summary>
    /// Static class which contains extension methods of generic type.
    /// </summary>
    public static class GenericTypeExtensions
    {
        /// <summary>
        /// Determines whether the object is null using the <see cref="Object.ReferenceEquals"/> static method of <see cref="Object"/> class
        /// to avoid using an overwritten operator logic.
        /// </summary>
        /// <typeparam name="TObject">The object type.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns>true if the object is null; otherwise, false.</returns>
        public static bool IsNull<TObject>(this TObject @object)
            where TObject : class
        {
            return Object.ReferenceEquals(@object, null);
        }

        /// <summary>
        /// Determines whether the object is not null using the <see cref="Object.ReferenceEquals"/> static method of <see cref="Object"/> class
        /// to avoid using an overwritten operator logic.
        /// </summary>
        /// <typeparam name="TObject">The object type.</typeparam>
        /// <param name="object">The object.</param>
        /// <returns>true if the object is not null; otherwise, false.</returns>
        public static bool IsNotNull<TObject>(this TObject @object)
            where TObject : class
        {
            return !IsNull(@object);
        }

        public static bool IsDefault<TValue>(this TValue value)
            where TValue : struct
        {
            return value.Equals(default(TValue));
        }
    }
}
