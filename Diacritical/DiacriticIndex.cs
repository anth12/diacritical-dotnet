using System.Collections.Generic;

namespace Diacritical
{
	internal class DiacriticIndex
	{
		public DiacriticIndex(IReadOnlyDictionary<char, string> map)
        {
            Map = map;
		}

		public IReadOnlyDictionary<char, string> Map { get; }
	}
}
