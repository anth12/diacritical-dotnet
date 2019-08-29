using System.Collections.Generic;

namespace Diacritical
{
	internal class DiacriticIndex
	{
		public DiacriticIndex(IReadOnlyDictionary<char, string> map, char[] keys)
		{
			Map = map;
			Keys = keys;
		}

		public IReadOnlyDictionary<char, string> Map { get; }
		public char[] Keys { get; }
	}
}
