using System.Collections.Generic;
using System.Threading.Tasks;
using Diacritical.Test.Mock;
using NUnit.Framework;

namespace Diacritical.Test;

public class DiacriticProviderTests
{
	[TestCase("Fußball", "Fussball")]
	[TestCase("İngiltere", "Ingiltere")]
	public void GivenCustomDiacriticProvider_ThenDefaultMapPreserved(string input, string expectedValue)
	{
		var result = input.RemoveDiacritics();

		Assert.That(result, Is.EqualTo(expectedValue));
	}

	[Test]
	public void GivenCustomDefaultMapping_ThenReplaceWithMapping()
	{
		const string x_lower = "x";
		const string x_upper = "X";
		var subject = "ₓ";

		var result = subject.RemoveDiacritics();
		Assert.That(result, Is.EqualTo(x_lower));

		DiacriticMap.AddProviders(new CustomDiacriticProvider(new Dictionary<char, string>
		{
			{ 'ₓ', x_upper }
		}));

		result = subject.RemoveDiacritics();
		Assert.That(result, Is.EqualTo(x_upper));
	}
}