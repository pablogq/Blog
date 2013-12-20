#region Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace Blog.Collections
{
    /// <summary>
    /// Represents a page of items.
    /// </summary>
    /// <typeparam name="TItem">The item type of the pager.</typeparam>
    public class Pager<TItem> : List<TItem>
    {
        /// <summary>
        /// Default page for the pager.
        /// </summary>
        public const int DefaultPage = 1;
        /// <summary>
        /// Default page size for the pager.
        /// </summary>
        public const int DefaultPageSize = 5;

        /// <summary>
        /// Creates a new instance of <see cref="Pager{T}"/> class.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="parameters">The pager parameters</param>
        public Pager(IEnumerable<TItem> source, PagerParameters parameters)
            : this(source, parameters.Page, parameters.PageSize)
        { }

        /// <summary>
        /// Creates a new instance of <see cref="Pager{T}"/> class.
        /// </summary>
        /// <param name="source">The source collection.</param>
        /// <param name="page">The current page for the pager.</param>
        /// <param name="pageSize">The size of the current page.</param>
        public Pager(IEnumerable<TItem> source, int? page = null, int? pageSize = null)
        {
            Guard.IsNotNull(source, "source");

            this.Page = page ?? DefaultPage;
            this.PageSize = pageSize ?? DefaultPageSize;
            this.TotalCount = source.Count();
            this.TotalPages = (int)Math.Ceiling(this.TotalCount / (double)this.PageSize);

            this.AddRange(source.Skip((this.Page - 1) * this.PageSize)
                                .Take(this.PageSize));
        }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; private set; }
        /// <summary>
        /// Gets the current page size.
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Gets the total count of the source collection.
        /// </summary>
        public int TotalCount { get; private set; }
        /// <summary>
        /// Gets the total of pages that the source collection is divided based on the page size.
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Gets the index where the page starts.
        /// </summary>
        public int From { get { return this.Page - DefaultPageSize < 1 ? 1 : this.Page - DefaultPageSize; } }
        /// <summary>
        /// Gets the index where the page ends.
        /// </summary>
        public int To { get { return this.Page + DefaultPageSize > this.TotalPages ? this.TotalPages : this.Page + DefaultPageSize; } }
        /// <summary>
        /// Determines if there is another page after the current page.
        /// </summary>
        public bool HasNextPage { get { return this.TotalPages > 1 && this.Page < this.TotalPages; } }
        /// <summary>
        /// Determines if there is a previous page before the current page.
        /// </summary>
        public bool HasPreviousPage { get { return this.Page > 1; } }
    }

    /// <summary>
    /// Provides a set of static methods for <see cref="Pager{T}"/>
    /// </summary>
    public static class Pager
    {
        /// <summary>
        /// Returns an empty <see cref="Pager{T}"/> that has the specified type argument.
        /// </summary>
        /// <typeparam name="TItem">The type to assign to the returned <see cref="Pager{T}"/></typeparam>
        /// <returns>An empty <see cref="Pager{T}"/> whose type argument is <see cref="TItem"/></returns>
        public static Pager<TItem> Emtpy<TItem>()
        {
            return EmptyPager<TItem>.Instance;
        }
    }
}
