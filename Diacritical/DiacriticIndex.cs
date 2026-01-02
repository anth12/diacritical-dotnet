using System.Collections.ObjectModel;

namespace Diacritical;

internal class DiacriticIndex(ReadOnlyDictionary<char, string> map)
{
    internal ReadOnlyDictionary<char, string> Map { get; } = map;
}