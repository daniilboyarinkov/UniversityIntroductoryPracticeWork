using System;
using System.Collections.Generic;

namespace TodoApp.BLogic.Extensions
{
    static public class IEnumerableForeach
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var cur in enumerable)
            {
                action(cur);
            }
        }
    }
}
