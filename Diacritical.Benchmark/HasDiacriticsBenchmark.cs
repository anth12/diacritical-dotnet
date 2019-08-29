using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace Diacritical.Benchmark
{
	[RankColumn, CsvExporter(CsvSeparator.Comma)]
	public class HasDiacriticsBenchmark
	{

		[GlobalSetup]
		public void Setup()
		{
			Diacritical.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);
			Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);
		}

		#region Diacritical

		[Benchmark]
		public bool Diacritical_LatinOnlyString() => Diacritical.StringExtensions.HasDiacritics(Constants.LatinString);

		[Benchmark]
		public bool Diacritical_ShortDiacriticString() => Diacritical.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public bool Diacritical_LongDiacriticString() => Diacritical.StringExtensions.HasDiacritics(Constants.LongDiacriticString);

		#endregion

		#region

		[Benchmark]
		public bool Diacritics_LatinOnlyString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.LatinString);

		[Benchmark]
		public bool Diacritics_ShortDiacriticString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public bool Diacritics_LongDiacriticString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.LongDiacriticString);
		
		#endregion
	}
}
