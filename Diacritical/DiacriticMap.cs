using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

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

		private static readonly ConcurrentQueue<IDiacriticProvider> Providers = new ConcurrentQueue<IDiacriticProvider>();

		public static void AddProvider(IDiacriticProvider provider)
		{
			if (Providers.Contains(provider))
				throw new Exception("Provider already added");

			Providers.Enqueue(provider);
			BuildIndex();
		}

		public static void AddProviders(IEnumerable<IDiacriticProvider> providers)
		{
			foreach (var provider in providers)
			{
				if (Providers.Contains(provider))
					throw new Exception("Provider already added");

				Providers.Enqueue(provider);
			}

			BuildIndex();
		}

		#endregion

		#region Index

		internal static DiacriticIndex Index;

		private static void BuildIndex()
		{
			var mappings = new Dictionary<char, string>();
			
			foreach (var diacriticProvider in Providers)
			{
				IDictionary<char, string> map = diacriticProvider.Provide();

				foreach (KeyValuePair<char, string> mapping in map)
				{
					mappings[mapping.Key] = mapping.Value;
				}
			}

            Index = new DiacriticIndex(mappings);
        }

		#endregion

	}
}
