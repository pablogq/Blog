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
        private string content;
        private string author;

        public Entry(string slug, string title, string content, string author)
        {
            Guard.IsNotNullOrEmpty(slug, "slug");

            this.slug = slug.ToLowerInvariant();
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        [Id]
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

        public string Content
        {
            get { return this.content; }
            set
            {
                Guard.IsNotNullOrEmpty(value, "content");

                this.content = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                Guard.IsNotNullOrEmpty(value, "author");

                this.author = value;
            }
        }

        public DateTime CreatedAt { get; set; }
        public bool IsPublished { get; set; }

        public void Update(Entry entry) 
        {
            Guard.IsNotNull(entry, "entry");

            this.Title = entry.Title;
            this.Content = entry.Content;
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
