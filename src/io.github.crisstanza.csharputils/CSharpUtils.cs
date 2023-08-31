using System.Reflection;

namespace src.io.github.crisstanza.csharputils
{
	public class CSharpUtils
	{
		public static string Version()
		{
			return Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}
