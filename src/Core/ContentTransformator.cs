#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog
{
    public static class ContentTransformator
    {
        private static Func<IContentTransformator> template = () => new NullContentTransformator();

        public static IContentTransformator Current { get { return template(); } }

        public static void SetContentTransformator(IContentTransformator transformator)
        {
            Guard.IsNotNull(transformator, "transformator");

            SetContentTransformator(() => transformator);
        }

        public static void SetContentTransformator(Func<IContentTransformator> templateMethod)
        {
            Guard.IsNotNull(templateMethod, "templateMethod");

            template = templateMethod;
        }
    }
}
