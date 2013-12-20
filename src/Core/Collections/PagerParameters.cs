#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Collections
{
    public class PagerParameters
    {
        public PagerParameters(int? page = null, int? pageSize = null)
        {
            this.Page = page;
            this.PageSize = pageSize;
        }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
