using System.Collections.Generic;
using NUnit.Framework;

namespace DotDiacritic.Test
{
	public class DiacriticProviderTests
	{
		[TestCase("Fußball", "Fussball")]
		[TestCase("İngiltere", "Ingiltere")]
		public void GivenCustomDiacriticProvider_ThenDefaultMapPreserved(string input, string expectedValue)
		{
			var result = input.RemoveDiacritics();

			Assert.AreEqual(expectedValue, result);
		}

		[TestCase("test@test.com", "test[at]test.com")]
		public void GivenCustomDiacriticProvider_ThenReplaceCustomCharacter(string input, string expectedValue)
		{
			var result = input.RemoveDiacritics();

			Assert.AreEqual(expectedValue, result);
		}

	}
}
