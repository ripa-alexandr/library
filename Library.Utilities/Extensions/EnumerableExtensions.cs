using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utilities.Extensions
{
    public static class EnumerableExtensions
    {
        public static ICollection<T> Update<T>(this ICollection<T> inner, ICollection<T> outer)
        {
            return inner.Clear();
        }

        private void MergeCollections<TSource, TDest>(IEnumerable<TSource> source, ICollection<TDest> destination, Func<TSource, TDest, bool> same) where TDest : class
        {
            source = source ?? Enumerable.Empty<TSource>();

            var insert = source.Where(x => !destination.Any(y => same(x, y))).ToArray();
            var delete = destination.Where(x => !source.Any(y => same(y, x))).ToArray();
            var update = source.Except(insert).ToArray();

            foreach (var item in insert)
                destination.Add(Mapper.Map<TSource, TDest>(item));

            foreach (var item in delete)
            {
                destination.Remove(item);
                _context.Set<TDest>().Remove(item);
            }

            foreach (var item in update)
                Mapper.Map(item, destination.First(x => same(item, x)));
        }
    }
}
