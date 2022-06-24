using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Text.Json;

namespace Diacritical.Import
{
    class Program
    {
        private const string Endpoint = "https://raw.githubusercontent.com/diacritics/database/dist/v1/diacritics.json";

        static async Task Main()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(Endpoint);
            var diacriticsMap = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, CultureVariation>>>(json) ?? new();
            var mappings = diacriticsMap.Values.SelectMany(x => x.Values.SelectMany(z => z.Variations.Values))
                .SelectMany(x => x.Equivalents.Select(a => (a.Raw, Base: x.Mapping.Base ?? x.Mapping.Decompose?.Value)))
                .Where(x => !string.IsNullOrEmpty(x.Base) && char.TryParse(x.Raw, out _))
                .OrderBy(x => x.Raw)
                .ToArray();

            await File.WriteAllLinesAsync("mappings.txt", mappings.Select(x => $"{{ '{x.Raw}', \"{x.Base}\" }},"));
        }

        #region Models

        public class Metadata
        {
            [JsonPropertyName("alphabet")]
            public string Alphabet { get; set; }

            [JsonPropertyName("continent")]
            public IList<string> Continent { get; set; }

            [JsonPropertyName("language")]
            public string Language { get; set; }

            [JsonPropertyName("languageNative")]
            public string LanguageNative { get; set; }

            [JsonPropertyName("source")]
            public IList<string> Source { get; set; }

            [JsonPropertyName("country")]
            public IList<string> Country { get; set; }
        }

        public class Decompose
        {
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }

        public class Mapping
        {

            [JsonPropertyName("base")]
            public string Base { get; set; }

            [JsonPropertyName("decompose")]
            public Decompose Decompose { get; set; }
        }

        public class Equivalent
        {
            [JsonPropertyName("raw")]
            public string Raw { get; set; }

            [JsonPropertyName("unicode")]
            public string Unicode { get; set; }

            [JsonPropertyName("htmlDecimal")]
            public string HtmlDecimal { get; set; }

            [JsonPropertyName("htmlHex")]
            public string HtmlHex { get; set; }

            [JsonPropertyName("encodedUri")]
            public string EncodedUri { get; set; }
        }

        public class Variation
        {

            [JsonPropertyName("case")]
            public string Case { get; set; }

            [JsonPropertyName("mapping")]
            public Mapping Mapping { get; set; }

            [JsonPropertyName("equivalents")]
            public IList<Equivalent> Equivalents { get; set; }
        }

        public class CultureVariation
        {
            [JsonPropertyName("metadata")]
            public Metadata Metadata { get; set; }

            [JsonPropertyName("data")]
            public Dictionary<string, Variation> Variations { get; set; }
        }

        #endregion

    }
}
