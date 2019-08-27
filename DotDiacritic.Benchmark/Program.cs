using BenchmarkDotNet.Running;

namespace DotDiacritic.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			var summary = BenchmarkRunner.Run<DiacriticMapBenchmark>();
		}
	}
}
