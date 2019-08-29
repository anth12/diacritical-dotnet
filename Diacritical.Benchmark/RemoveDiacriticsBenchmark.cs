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
		public string Diacritical_ShortLatinString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.ShortLatinString);
		
		[Benchmark]
		public string Diacritical_LongLatinString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.LongLatinString);

		[Benchmark]
		public string Diacritical_ShortDiacriticString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public string Diacritical_LongDiacriticString() => Diacritical.StringExtensions.RemoveDiacritics(Constants.LongDiacriticString);

		#endregion

		#region

		[Benchmark]
		public string Diacritics_ShortLatinOnlyString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.ShortLatinString);

		[Benchmark]
		public string Diacritics_LongLatinOnlyString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.LongLatinString);

		[Benchmark]
		public string Diacritics_ShortDiacriticString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.ShortDiacriticString);

		[Benchmark]
		public string Diacritics_LongDiacriticString() => Diacritics.Extensions.StringExtensions.RemoveDiacritics(Constants.LongDiacriticString);


		#endregion

	}
}
