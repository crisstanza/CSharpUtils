using System;

namespace io.github.crisstanza.csharputils
{
    public class NumberUtils
    {
        private const double _k = 1024;
        private const double _m = _k * _k;
        private const double _g = _k * _k * _k;
        private const double _t = _k * _k * _k * _k;

        public string SizeFromBytes(int bytes)
        {
            if (bytes < _k)
            {
                return bytes + " byte" + (bytes == 1 ? "" : "s");
            }
            else if (bytes < _m)
            {
                return this.Truncate2(bytes / _k) + " KB";
            }
            else if (bytes < _g)
            {
                return this.Truncate2(bytes / _m) + " MB";
            }
            else if (bytes < _t)
            {
                return this.Truncate2(bytes / _g) + " GB";
            }
            else
            {
                return bytes + " bytes";
            }
        }

        public string Truncate2(double number)
        {
            double power = Math.Pow(10, 2);
            return (Math.Truncate(number * power) / power).ToString();
        }

        public string ToHexa(int number, int size)
        {
            return "0x" + number.ToString("X" + size);
        }
    }
}
