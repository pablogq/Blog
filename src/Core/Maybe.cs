#region Libraries
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

//Taken from http://blog.ploeh.dk/2011/02/04/TheBCLalreadyhasaMaybemonad/
//           https://github.com/ploeh/Booking/blob/master/BookingDomainModel/Maybe.cs
namespace Blog
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> values;

        public Maybe()
        {
            this.values = Enumerable.Empty<T>();
        }

        public Maybe(T value)
        {
            this.values = value != null ? new[] { value } : Enumerable.Empty<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Maybe<T> Do(Action<T> action) 
        {
            this.values.ForEach(action);
            return this;
        }
    }

    public static class Maybe
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> Empty<T>()
        {
            return EmptyMaybe<T>.Instance;
        }
    }
}
