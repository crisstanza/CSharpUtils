using System.IO;
using System.Reflection;

namespace io.github.crisstanza.csharputils
{
	public class FileSystemUtils
	{
		public string CurrentPath()
		{
            Assembly assembly = Assembly.GetEntryAssembly();
            string location = assembly == null ? Assembly.GetCallingAssembly().Location : assembly.Location;
            return Path.GetDirectoryName(location) + Path.DirectorySeparatorChar;
		}
	}
}
