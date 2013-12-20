#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Collections
{
    internal class EmptyPager<TItem>
    {
        private static volatile Pager<TItem> instance;

        public static Pager<TItem> Instance
        {
            get
            {
                if (EmptyPager<TItem>.instance.IsNull())
                {
                    EmptyPager<TItem>.instance = new Pager<TItem>(Enumerable.Empty<TItem>().AsQueryable());
                }
                return EmptyPager<TItem>.instance;
            }
        }
    }
}
