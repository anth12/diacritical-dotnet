using System.Collections.Generic;

namespace DotDiacritic.Test.Mock
{
	internal class CustomDiacriticProvider : IDiacriticProvider
	{
		private readonly Dictionary<char, string> _map;

		public CustomDiacriticProvider(Dictionary<char, string> map)
		{
			_map = map;
		}

		public IDictionary<char, string> Provide()
		{
			return _map;
		}
	}
}
