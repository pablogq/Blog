#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog
{
    public class NullContentTransformator : IContentTransformator
    {
        public string Transform(string content)
        {
            return content;
        }
    }
}
