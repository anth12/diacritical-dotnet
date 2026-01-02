
namespace Diacritical;

public static class StringExtensions
{
	extension(string input)
	{
		public string RemoveDiacritics()
		{
			if (string.IsNullOrEmpty(input))
				return input;
		
			var index = DiacriticMap.Index;
		
			for (int i = 0; i < input.Length; i++)
			{
				if (index.Map.TryGetValue(input[i], out var replacement))
				{
					// First replacement found, allocate StringBuilder
					var sb = StringBuilderCache.Acquire(input.Length + (replacement.Length - 1));
					if (i > 0)
						sb.Append(input, 0, i);
				
					sb.Append(replacement);
					for (int j = i + 1; j < input.Length; j++)
					{
						if (index.Map.TryGetValue(input[j], out var repl))
							sb.Append(repl);
						else
							sb.Append(input[j]);
					}

					return StringBuilderCache.GetStringAndRelease(sb);
				}
			}
			return input;
		}

		public bool HasDiacritics()
		{
			if (string.IsNullOrEmpty(input))
				return false;
		
			var index = DiacriticMap.Index;
		
			foreach (var c in input)
			{
				if (index.Map.ContainsKey(c))
					return true;
			}
			return false;
		}
	}
}