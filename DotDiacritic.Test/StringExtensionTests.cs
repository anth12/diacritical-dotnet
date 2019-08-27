using NUnit.Framework;

namespace DotDiacritic.Test
{
	public class StringExtensionTests
	{
		[TestCase(null)]
		[TestCase("")]
		public void RemoveDiacritics_GivenNullOrEmpty_ThenReturnInitial(string input)
		{
			var result = input.RemoveDiacritics();

			Assert.AreEqual(input, result);
		}

		[TestCase("Hello")]
		[TestCase("ABCdef123")]
		[TestCase("!\"£$%^&*()_+")]
		public void RemoveDiacritics_GivenNoDiacritics_ThenReturnInitial(string input)
		{
			var result = input.RemoveDiacritics();

			Assert.AreEqual(input, result);
		}

		[TestCase("Fußball", "Fussball")]
		[TestCase("İngiltere", "Ingiltere")]
		public void RemoveDiacritics_GivenDiacritics_ThenReplace(string input, string expectedValue)
		{
			var result = input.RemoveDiacritics();

			Assert.AreEqual(expectedValue, result);
		}
	}
}
