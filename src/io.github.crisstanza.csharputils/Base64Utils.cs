using System;

namespace io.github.crisstanza.csharputils
{
	public class Base64Utils
	{
		public string FromByteArray(byte[] array)
		{
			return array == null ? null : Convert.ToBase64String(array);
		}
		public byte[] ToByteArray(string value, bool fixInput)
		{
			if (value == null)
			{
				return null;
			}
			else if (fixInput)
			{
				return Convert.FromBase64String(this.FixInput(value));
			}
			else
			{
				return Convert.FromBase64String(value);
			}
		}
		public byte[] ToByteArray(string value)
		{
			return ToByteArray(value, false);
		}
		private string FixInput(string value)
		{
			return value.Replace(' ', '+');
		}
	}
}
