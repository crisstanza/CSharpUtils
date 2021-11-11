using System.IO;
using System.Reflection;

namespace io.github.crisstanza.csharputils
{
	public class FileSystemUtils
	{
		public string CurrentPath()
		{
			return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
		}
	}
}
