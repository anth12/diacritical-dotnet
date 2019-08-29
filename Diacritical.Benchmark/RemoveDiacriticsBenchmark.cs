using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace Diacritical.Benchmark
{
	[ShortRunJob]
	[CsvExporter(CsvSeparator.Comma)]
	[RankColumn]
	public class RemoveDiacriticsBenchmark
	{

		[GlobalSetup]
		public void Setup()
		{
			Diacritical.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);
			Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);
		}

		#region Diacritical

		[Benchmark]
		public string Diacritical_LatinOnlyString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.LatinString);

		[Benchmark]
		public string Diacritical_ShortDiacriticString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public string Diacritical_LongDiacriticString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.LongDiacriticString);

		#endregion

		#region

		[Benchmark]
		public string Diacritics_LatinOnlyString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.LatinString);

		[Benchmark]
		public string Diacritics_ShortDiacriticString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public string Diacritics_LongDiacriticString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.LongDiacriticString);


		#endregion

	}
}
