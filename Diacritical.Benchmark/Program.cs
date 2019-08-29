using System;
using BenchmarkDotNet.Running;

namespace Diacritical.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<RemoveDiacriticsBenchmark>();
			Console.WriteLine("Press any key to continue");
			Console.ReadLine();
			BenchmarkRunner.Run<HasDiacriticsBenchmark>();
		}
	}
}
