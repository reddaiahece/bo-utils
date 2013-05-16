using System;

namespace BOUtilsAddin
{
    static class ExcelArray<T>
    {
        public static T[,] Create(int nbRow, int nbColumn) {
            return (T[,])Array.CreateInstance(typeof(T), new [] { nbRow, nbColumn }, new [] { 1, 1 });
        }

        public static T[] Create(int nbRow) {
            return new T[nbRow + 1];
        }

        public static T[,] Get(object value) {
            if (value != null && value.GetType().IsArray)
                return (T[,])value;
            var array = (T[,])Array.CreateInstance(typeof(T), new[] { 1, 1 }, new[] { 1, 1 });
            array[1, 1] = (T)value;
            return array;
        }
    }

    static class Array<T>
    {
        public static T[] Join(T[] a, T[] b)
        {
            var table = new T[a.Length + b.Length];
            for (int i = 0; i < a.Length; i++)
                table[i] = a[i];
            for (int i = 0, ii = a.Length; i < b.Length; i++)
                table[ii++] = b[i];
            return table;
        }

    }
}
