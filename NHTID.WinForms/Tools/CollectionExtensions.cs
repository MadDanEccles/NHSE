using System;

namespace Nhtid.WinForms.Tools
{
    public static class CollectionExtensions
    {
        public static int IndexOfMin<T>(this T[] collection) where T : IComparable<T>
        {
            T min = collection[0];
            int result = 0;
            for (int x = 1; x < collection.Length; x++)
            {
                if (collection[x].CompareTo(min) < 0)
                {
                    min = collection[x];
                    result = x;
                }
            }

            return result;
        }
    }
}