namespace Diacritical;

public static class StringExtensions
{
	extension(string source)
	{
		public string RemoveDiacritics()
		{
			if (string.IsNullOrEmpty(source))
				return source;

			DiacriticIndex index = DiacriticMap.Index;
			var result = StringBuilderCache.Acquire(source.Length);

			foreach (var character in source)
			{
				if (index.Map.TryGetValue(character, out var replacement))
				{
					result.Append(replacement);
				}
				else
				{
					result.Append(character);
				}
			}

			return StringBuilderCache.GetStringAndRelease(result);
		}

		public bool HasDiacritics()
		{
			if (string.IsNullOrEmpty(source))
				return false;

			DiacriticIndex index = DiacriticMap.Index;

			foreach (var character in source)
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