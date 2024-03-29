﻿using System.Text;

namespace io.github.crisstanza.csharputils
{
    public class ArrayUtils
    {
        public int Size(byte[] array)
        {
            return array == null ? 0 : array.Length;
        }
        public int StringSize(byte[] array)
        {
            if (array == null)
            {
                return 0;
            }
            int i = 0;
            for (; i < array.Length && array[i] > 0; i++) ;
            return i;
        }
        public string Join(int start, object[] array)
        {
            StringBuilder sb = new StringBuilder();
            if (array != null)
            {
                for (int i = start; i < array.Length; i++)
                {
                    sb.Append(array[i]);
                }
            }
            return sb.ToString();
        }
    }
}
