using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;

namespace DotDiacritic.Benchmark
{
	[RankColumn, CsvExporter(CsvSeparator.Comma)]
	public class DiacriticMapBenchmark
	{
		[Benchmark]
		public string LatinOnlyString() => "ABCdef123".RemoveDiacritics();

		[Benchmark]
		public string ShortDiacriticString() => "Ruşen Eşref Ünaydın".RemoveDiacritics();

		[Benchmark]
		public string LongDiacriticString() => @"Každý má právo na vzdělání. Vzdělání nechť je bezplatné, alespoň v počátečních a základních stupních. Základní vzdělání je povinné. Technické a odborné vzdělání budiž všeobecně přístupné a rovněž vyšší vzdělání má být stejně přístupné všem podle schopností.
Vzdělání má směřovat k plnému rozvoji lidské osobnosti a k posílení úcty k lidským právům a základním svobodám.Má napomáhat k vzájemnému porozumění, snášenlivosti a přátelství mezi všemi národy a všemi skupinami rasovými i náboženskými, jakož i k rozvoji činnosti Spojených národů pro zachování míru.
Rodiče mají přednostní právo volit druh vzdělání pro své děti.".RemoveDiacritics();

	}
}
