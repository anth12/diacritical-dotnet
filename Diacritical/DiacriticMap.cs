using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Diacritical;

public class DiacriticMap
{
	static DiacriticMap()
	{
		AddProviders(new DefaultDiacriticProvider());
	}

	#region Providers

	private static readonly ConcurrentDictionary<IDiacriticProvider, int> Providers = new();

	public static void AddProviders(params IDiacriticProvider[] providers)
	{
		foreach (var provider in providers)
		{
			if (!Providers.TryAdd(provider, Providers.Count))
				throw new Exception("Provider already added");
		}
		
		BuildIndex();
	}

	public static void RemoveProvider(IDiacriticProvider provider)
	{
		Providers.TryRemove(provider, out _);
		BuildIndex();
	}

	#endregion

	#region Index

	internal static DiacriticIndex Index;

	private static void BuildIndex()
	{
		var mappings = new Dictionary<char, string>();
		foreach (var diacriticProvider in Providers.OrderBy(kv => kv.Value).Select(kv => kv.Key))
		{
			foreach (var mapping in diacriticProvider.Provide())
				mappings[mapping.Key] = mapping.Value;
		}
		
		Interlocked.Exchange(ref Index, new DiacriticIndex(new ReadOnlyDictionary<char, string>(mappings)));
	}

	#endregion

}