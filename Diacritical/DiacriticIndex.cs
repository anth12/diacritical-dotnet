using System.Collections.ObjectModel;

namespace Diacritical;

internal class DiacriticIndex(ReadOnlyDictionary<char, string> map)
{
	public ReadOnlyDictionary<char, string> Map { get; } = map;
}