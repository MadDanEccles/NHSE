using System;
using System.Collections.Generic;

namespace Nhtid.WinForms
{
    public static class EnumerableExtensions
    {
        public static int IndexOfFirst<T>(this IList<T> list, Predicate<T> predicate)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (predicate(list[i]))
                    return i;
            }

            return -1;
        }
    }
}