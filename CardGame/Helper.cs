using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class  Helper
    {
        public static IEnumerable<T> IfThenElse<T>(
            this IEnumerable<T> elements,
            Func<bool> condition,
            Func<IEnumerable<T>, IEnumerable<T>> thenPath,
            Func<IEnumerable<T>, IEnumerable<T>> elsePath)
        {
            return condition()
                ? thenPath(elements)
                : elsePath(elements);
        }
        public static IEnumerable<T> Shuffle<T>(
            this IEnumerable<T> elements)
        {
            Random r = new Random();
            var list = elements.ToList();
            for (int n = list.Count() - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                var temp = list[n];
                list[n] = list[k];
                list[k] = temp;
            }
            return list;
        }
    }
}
