using System.Collections.Generic;

namespace Diacritical;

public interface IDiacriticProvider
{
	IDictionary<char, string> Provide();
}