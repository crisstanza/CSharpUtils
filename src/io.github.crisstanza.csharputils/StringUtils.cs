using System;

namespace io.github.crisstanza.csharputils
{
	public class StringUtils
	{
        public string Default(string value, string fallback)
        {
            return this.IsBlank(value) ? fallback : value;
        }

        public bool IsBlank(string value)
		{
			return value == null || value.Trim().Length == 0;
		}
	}
}
