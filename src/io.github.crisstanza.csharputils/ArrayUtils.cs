using System.Text;

namespace io.github.crisstanza.csharputils
{
	public class ArrayUtils
	{
		public string Join(int start, object[] array)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = start; i < array.Length; i++)
			{
				sb.Append(array[i]);
			}
			return sb.ToString();
		}
	}
}
