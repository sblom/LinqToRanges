using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToRanges
{
    public static class RangeExtensions
    {
        public static IEnumerator<int> GetEnumerator(this Range range)
        {
            for (int i = range.Start.Value; i < range.End.Value || (range.End.Value == 0 && range.End.IsFromEnd); i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> AsEnumerable(this Range range)
        {
            for (int i = range.Start.Value; i < range.End.Value || (range.End.Value == 0 && range.End.IsFromEnd); i++)
            {
                yield return i;
            }
        }

        public static IEnumerable<int> Take(this Range range, int n)
        {
            return range.AsEnumerable().Take(n);
        }

        public static IEnumerable<int> Select(this Range range, Func<int, int> fun)
        {
            return range.AsEnumerable().Select(fun);
        }

        public static IEnumerable<int> Where(this Range range, Func<int, bool> fun)
        {
            return range.AsEnumerable().Where(fun);
        }

        public static IEnumerable<TResult> SelectMany<TResult>(this Range range, Func<int, IEnumerable<TResult>> fun)
        {
            return range.AsEnumerable().SelectMany(fun);
        }

        public static IEnumerable<TResult> SelectMany<TCollection, TResult>(this Range range, Func<int, IEnumerable<TCollection>> fun1, Func<int, TCollection, TResult> fun2)
        {
            return Enumerable.SelectMany<int, TCollection, TResult>(range.AsEnumerable(), fun1, fun2);
        }

        // This was BY FAR the hardest puzzle to solve. I couldn't find good docs for what defines "query pattern" and
        // what assumptions the compiler makes while emitting SelectMany() calls, but I finally found something that works.
        // Specifically, this enables a Range to be second or later in a list of nested froms in LINQ query syntax.
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Range> fun1, Func<TSource, int, TResult> fun2)
        {
            foreach (var s in source)
            {
                var range = fun1(s);

                foreach (var t in range.AsEnumerable())
                {
                    yield return fun2(s, t);
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TResult>(this Range range, Func<int, Range> fun1, Func<int, int, TResult> fun2)
        {
            foreach (var s in range.AsEnumerable())
            {
                var range2 = fun1(s);

                foreach (var t in range2.AsEnumerable())
                {
                    yield return fun2(s, t);
                }
            }
        }
    }
}
