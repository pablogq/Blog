#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog
{
    internal class EmptyMaybe<T>
    {
        private static volatile Maybe<T> instance;

        public static Maybe<T> Instance
        {
            get
            {
                if (EmptyMaybe<T>.instance.IsNull())
                {
                    EmptyMaybe<T>.instance = new Maybe<T>();
                }
                return EmptyMaybe<T>.instance;
            }
        }
    }
}
