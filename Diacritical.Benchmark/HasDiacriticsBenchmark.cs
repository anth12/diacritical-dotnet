using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace Diacritical.Benchmark
{
	[ShortRunJob]
	[CsvExporter(CsvSeparator.Comma)]
	[RankColumn]
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
		public bool Diacritical_ShortLatinString() => Diacritical.StringExtensions.HasDiacritics(Constants.ShortLatinString);

		[Benchmark]
		public bool Diacritical_LongLatinString() => Diacritical.StringExtensions.HasDiacritics(Constants.LongLatinString);

		[Benchmark]
		public bool Diacritical_ShortDiacriticString() => Diacritical.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public bool Diacritical_LongDiacriticString() => Diacritical.StringExtensions.HasDiacritics(Constants.LongDiacriticString);

		#endregion

		#region

		[Benchmark]
		public bool Diacritics_ShortLatinString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.ShortLatinString);

		[Benchmark]
		public bool Diacritics_LongLatinString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.LongLatinString);

		[Benchmark]
		public bool Diacritics_ShortDiacriticString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public bool Diacritics_LongDiacriticString() => Diacritics.Extensions.StringExtensions.HasDiacritics(Constants.LongDiacriticString);
		
		#endregion
	}
}
