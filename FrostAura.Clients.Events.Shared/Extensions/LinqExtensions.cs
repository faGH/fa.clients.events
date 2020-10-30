using System.Collections.Generic;
using System;

namespace FrostAura.Clients.Events.Shared.Extensions
{
    /// <summary>
    /// Linq extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Get a distinct collection.
        /// </summary>
        /// <typeparam name="TSource">Source collection type.</typeparam>
        /// <typeparam name="TKey">Key to perform distinct check on.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="keySelector">Key to perform distinct check on.</param>
        /// <returns>Filtered collection.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
