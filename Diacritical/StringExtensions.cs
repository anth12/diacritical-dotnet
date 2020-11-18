using System.Text;

namespace Diacritical
{
	public static class StringExtensions
	{
		public static string RemoveDiacritics(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return source;

			DiacriticIndex index = DiacriticMap.Index;
			var result = new StringBuilder(source.Length);

            string replacement;
			foreach (var character in source)
            {
                if (index.Map.TryGetValue(character, out replacement))
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

			DiacriticIndex index = DiacriticMap.Index;

			foreach (char character in source)
			{
				if (index.Map.ContainsKey(character))
				{
					return true;
				}
			}

			return false;
		}
	}
}
