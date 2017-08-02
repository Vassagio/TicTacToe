using System.Collections.Generic;
using System.Linq;

namespace Project.Utilities {
    public static class EnumerableExtensions {
        public static IEnumerable<T> RepeatSequence<T>(this IEnumerable<T> source, int count) {
            return Enumerable.Range(1, count).SelectMany(index => source);
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> source, int count) => 
            from item in source from index in Enumerable.Range(1, count) select item;
    }
}