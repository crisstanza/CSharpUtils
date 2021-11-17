using System.Diagnostics;
using System.IO;
using System.Threading;

namespace io.github.crisstanza.csharputils
{
	public class DiagnosticsUtils
	{
		public class CpuDiagnostics
		{
			public float InstanceCounter { get; set; }
			public float ProcessorCounter { get; set; }
			public string InstanceName { get; set; }
		}

		public CpuDiagnostics GetCpuDiagnostics()
		{
			CpuDiagnostics cpuDiagnostics = new CpuDiagnostics();

			string instanceName = GetInstanceNameForProcessId(Process.GetCurrentProcess().Id);

			PerformanceCounter processCounter = new PerformanceCounter();
			processCounter.CategoryName = "Process";
			processCounter.CounterName = "% Processor Time";
			processCounter.InstanceName = instanceName;

			PerformanceCounter cpuCounter = new PerformanceCounter();
			cpuCounter.CategoryName = "Processor";
			cpuCounter.CounterName = "% Processor Time";
			cpuCounter.InstanceName = "_Total";

			processCounter.NextValue();
			cpuCounter.NextValue();
			Thread.Sleep(250);

			cpuDiagnostics.InstanceCounter = processCounter.NextValue();
			cpuDiagnostics.ProcessorCounter = cpuCounter.NextValue();
			cpuDiagnostics.InstanceName = instanceName;

			return cpuDiagnostics;
		}

		private string GetInstanceNameForProcessId(int processId)
		{
			Process process = Process.GetProcessById(processId);
			string processName = Path.GetFileNameWithoutExtension(process.ProcessName);

			PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
			string[] instanceNames = cat.GetInstanceNames();

			foreach (string instance in instanceNames)
			{
				if (instance.StartsWith(processName))
				{
					using (PerformanceCounter cnt = new PerformanceCounter("Process", "ID Process", instance, true))
					{
						int val = (int)cnt.RawValue;
						if (val == processId)
						{
							return instance;
						}
					}
				}
			}
			return null;
		}
	}
}
