using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DotDiacritic
{
	public class DiacriticMap
	{
		static DiacriticMap()
		{
			AddProviders(new []
			{
				new DefaultDiacriticProvider()
			});
		}

		#region Providers

		internal static readonly ConcurrentBag<IDiacriticProvider> Providers = new ConcurrentBag<IDiacriticProvider>();

		public static void AddProvider(IDiacriticProvider provider)
		{
			if (Providers.Contains(provider))
				throw new Exception("Provider already added");

			Providers.Add(provider);
			ResetMap();
		}

		public static void AddProviders(IEnumerable<IDiacriticProvider> providers)
		{
			foreach (var provider in providers)
			{
				if (Providers.Contains(provider))
					throw new Exception("Provider already added");

				Providers.Add(provider);
			}

			ResetMap();
		}

		#endregion

		#region Map

		internal static Lazy<IReadOnlyDictionary<char, string>> Map;

		private static void ResetMap()
		{
			Map = new Lazy<IReadOnlyDictionary<char, string>>(()=>
			{
				var result = new ConcurrentDictionary<char, string>();

				foreach (var diacriticProvider in Providers)
				{
					IDictionary<char, string> map = diacriticProvider.Provide();

					foreach (KeyValuePair<char, string> mapping in map)
					{
						result.TryAdd(mapping.Key, mapping.Value);
					}
				}

				return result;
			}, LazyThreadSafetyMode.PublicationOnly);
		}

		#endregion

	}
}
