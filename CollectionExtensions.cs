using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClausaComm_Installer
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ForEach<T>(this T[] arr, Action<T> action)
        {
            for (int i = 0; i < arr.Length; ++i)
                action.Invoke(arr[i]);

            return arr;
        }
    }
}
