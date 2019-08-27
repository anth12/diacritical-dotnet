using System.Text;

namespace DotDiacritic
{
	public static class StringExtensions
	{
		public static string RemoveDiacritics(this string source)
		{
			if (string.IsNullOrEmpty(source))
				return source;
			
			var result = new StringBuilder(source.Length);

			foreach (char character in source)
			{
				if (DiacriticMap.Map.Value.TryGetValue(character, out string replacement))
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
	}
}
