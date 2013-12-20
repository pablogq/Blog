#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.ServiceModel
{
    [Serializable]
    public class EntryContract
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Markdown { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
