#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
#endregion

namespace Blog.Infrastructure.Markdown
{
    public class MarkdownContentTransformator : IContentTransformator
    {
        private readonly MarkdownSharp.Markdown markdown;
        public MarkdownContentTransformator()
        {
            this.markdown = new MarkdownSharp.Markdown();
        }

        public string Transform(string content)
        {
            return this.markdown.Transform(content);
        }
    }
}
