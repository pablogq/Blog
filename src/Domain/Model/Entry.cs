#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Domain.Model
{
    [Serializable]
    public class Entry : IEquatable<Entry>
    {
        private readonly string slug;
        private string title;
        private string markdown;
        private string author;

        public Entry(string slug, string title, string markdown, string author)
        {
            Guard.IsNotNullOrEmpty(slug, "slug");

            this.slug = slug.ToLowerInvariant();
            this.Title = title;
            this.Markdown = markdown;
            this.Author = author;
        }

        public string Slug { get { return this.slug; } }

        public string Title 
        {
            get { return this.title; }
            set
            {
                Guard.IsNotNullOrEmpty(value, "title");

                this.title = value;
            }
        }

        public string Markdown
        {
            get { return this.markdown; }
            set
            {
                Guard.IsNotNullOrEmpty(value, "markdown");

                this.markdown = value;
            }
        }

        public string Author
        {
            get { return this.markdown; }
            set
            {
                Guard.IsNotNullOrEmpty(value, "author");

                this.author = value;
            }
        }

        public DateTime CreatedAt { get; set; }

        public void Update(Entry entry) 
        {
            Guard.IsNotNull(entry, "entry");

            this.Title = entry.Title;
            this.Markdown = entry.Markdown;
            this.Author = entry.Author;
        }

        public bool Equals(Entry other)
        {
            if (other.IsNull()) 
            {
                return false;
            }
            return String.Equals(this.Slug, other.Slug);
        }

        public override bool Equals(object obj)
        {
            Entry other = obj as Entry;
            if (other.IsNull()) 
            {
                return base.Equals(obj);
            }
            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Slug.GetHashCode() ^ 137;
        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
