using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diacritical
{
	public static class StringExtensions
	{
		public static string RemoveDiacritics(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return source;

			DiacriticIndex index = DiacriticMap.Index.Value;
			var result = new StringBuilder(source.Length);

			foreach (char character in source)
			{
				if (index.Map.TryGetValue(character, out string replacement))
				{
					result.Append(replacement);
				}
				else
				{
					result.Append(character);
				}
			}

			return result.ToString();
		}

		public static bool HasDiacritics(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return false;

			DiacriticIndex index = DiacriticMap.Index.Value;

			return source.IndexOfAny(index.Keys) > -1;
		}
	}
}
