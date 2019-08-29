using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Diacritical
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
			BuildIndex();
		}

		public static void AddProviders(IEnumerable<IDiacriticProvider> providers)
		{
			foreach (var provider in providers)
			{
				if (Providers.Contains(provider))
					throw new Exception("Provider already added");

				Providers.Add(provider);
			}

			BuildIndex();
		}

		#endregion

		#region Map

		internal static Lazy<DiacriticIndex> Index;

		private static void BuildIndex()
		{
			Index = new Lazy<DiacriticIndex>(()=>
			{
				var mappings = new ConcurrentDictionary<char, string>();

				foreach (var diacriticProvider in Providers)
				{
					IDictionary<char, string> map = diacriticProvider.Provide();

					foreach (KeyValuePair<char, string> mapping in map)
					{
						mappings.TryAdd(mapping.Key, mapping.Value);
					}
				}

				return new DiacriticIndex(mappings, mappings.Keys.ToArray());
			}, LazyThreadSafetyMode.PublicationOnly);
		}

		#endregion

	}
}
