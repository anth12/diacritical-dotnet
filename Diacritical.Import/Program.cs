using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Diacritical.Import
{
	class Program
	{
		private const string Endpoint = "https://raw.githubusercontent.com/diacritics/database/dist/v1/diacritics.json";

		static async Task Main(string[] args)
		{
			using (var client = new HttpClient())
			{
				var json = await client.GetStringAsync(Endpoint);
				var diacriticsMap = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, CultureVariation>>>(json);
				var b = diacriticsMap.Values.SelectMany(x => x.Values.SelectMany(z => z.Variations.Values))
					.SelectMany(x => x.Equivalents.Select(a => (a.Raw, x.Mapping.Base)))
					.ToArray();

			}
		}

		#region Models

		public class Metadata
		{
			[JsonProperty("alphabet")]
			public string Alphabet { get; set; }

			[JsonProperty("continent")]
			public IList<string> Continent { get; set; }

			[JsonProperty("language")]
			public string Language { get; set; }

			[JsonProperty("languageNative")]
			public string LanguageNative { get; set; }

			[JsonProperty("source")]
			public IList<string> Source { get; set; }

			[JsonProperty("country")]
			public IList<string> Country { get; set; }
		}

		public class Mapping
		{

			[JsonProperty("base")]
			public string Base { get; set; }
		}

		public class Equivalent
		{

			[JsonProperty("raw")]
			public string Raw { get; set; }

			[JsonProperty("unicode")]
			public string Unicode { get; set; }

			[JsonProperty("htmlDecimal")]
			public string HtmlDecimal { get; set; }

			[JsonProperty("htmlHex")]
			public string HtmlHex { get; set; }

			[JsonProperty("encodedUri")]
			public string EncodedUri { get; set; }
		}

		public class Variation
		{

			[JsonProperty("case")]
			public string Case { get; set; }

			[JsonProperty("mapping")]
			public Mapping Mapping { get; set; }

			[JsonProperty("equivalents")]
			public IList<Equivalent> Equivalents { get; set; }
		}

		public class CultureVariation
		{
			[JsonProperty("metadata")]
			public Metadata Metadata { get; set; }

			[JsonProperty("data")]
			public Dictionary<string, Variation> Variations { get; set; }
		}
		
		#endregion

	}
}
