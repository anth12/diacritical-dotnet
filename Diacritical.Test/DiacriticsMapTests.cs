using System;
using System.Collections.Generic;
using Diacritical.Test.Mock;
using NUnit.Framework;

namespace Diacritical.Test;

public class DiacriticsMapTests
{
	[Test]
	public void AddProvider_GivenDuplicate_ThenThrows()
	{
		var mockProvider = new CustomDiacriticProvider(new Dictionary<char, string>());
		DiacriticMap.AddProvider(mockProvider);

		Assert.Throws<Exception>(() =>
			DiacriticMap.AddProvider(mockProvider));
	}

	[Test]
	public void AddProviders_GivenDuplicate_ThenThrows()
	{
		var mockProviders = new []
		{
			new CustomDiacriticProvider(new Dictionary<char, string>()),
			new CustomDiacriticProvider(new Dictionary<char, string>())
		};

		DiacriticMap.AddProviders(mockProviders);

		Assert.Throws<Exception>(() =>
			DiacriticMap.AddProviders(mockProviders));
	}

	[Test]
	public void AddProviders_GivenDuplicateMappings_ThenTakeLast()
	{
		var mockProviders = new[]
		{
			new CustomDiacriticProvider(new Dictionary<char, string>{ { '~', "1" }}),
			new CustomDiacriticProvider(new Dictionary<char, string>{ { '~', "2" }})
		};

		DiacriticMap.AddProviders(mockProviders);

		var result = "~".RemoveDiacritics();
		Assert.Equals("2", result);
	}
}