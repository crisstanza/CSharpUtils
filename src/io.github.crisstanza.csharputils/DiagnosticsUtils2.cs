using System.Diagnostics;
using System.IO;
using System.Threading;

namespace io.github.crisstanza.csharputils
{
	public class DiagnosticsUtils2
	{
		public class PerformanceCounters
		{
			public string InstanceName { get; set; }
			public PerformanceCounter InstanceCounter { get; set; }
			public PerformanceCounter CpuCounter { get; set; }
		}
		public class CpuDiagnostics
		{
			public float InstanceCounter { get; set; }
			public float ProcessorCounter { get; set; }
			public string InstanceName { get; set; }
		}

		public PerformanceCounters GetPerformanceCounters()
		{
			string instanceName = GetInstanceNameForProcessId(Process.GetCurrentProcess().Id);
			PerformanceCounter instanceCounter = new PerformanceCounter()
			{
				CategoryName = "Process",
				CounterName = "% Processor Time",
				InstanceName = instanceName
			};
			PerformanceCounter cpuCounter = new PerformanceCounter()
			{
				CategoryName = "Processor",
				CounterName = "% Processor Time",
				InstanceName = "_Total"
			};
			instanceCounter.NextValue();
			cpuCounter.NextValue();
			Thread.Sleep(1);
			return new PerformanceCounters()
			{
				InstanceName = instanceName,
				InstanceCounter = instanceCounter,
				CpuCounter = cpuCounter
			};
		}

		public CpuDiagnostics GetCpuDiagnostics(PerformanceCounters performanceCounters)
		{
			CpuDiagnostics cpuDiagnostics = new CpuDiagnostics()
			{
				InstanceCounter = performanceCounters.InstanceCounter.NextValue(),
				ProcessorCounter = performanceCounters.CpuCounter.NextValue(),
				InstanceName = performanceCounters.InstanceName
			};
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
