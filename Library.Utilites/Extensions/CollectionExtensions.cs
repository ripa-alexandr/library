using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Utilites.Extensions
{
    /// <summary>
    /// The collection extensions.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// The select empty if null.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public static IEnumerable<TResult> SelectNull<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            if (source == null) 
                return Enumerable.Empty<TResult>();

            return source.Select(selector);
        }
    }
}
