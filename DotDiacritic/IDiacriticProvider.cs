using System.Collections.Generic;

namespace DotDiacritic
{
	public interface IDiacriticProvider
	{
		IDictionary<char, string> Provide();
	}
}
