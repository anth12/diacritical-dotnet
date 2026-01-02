using NUnit.Framework;

namespace Diacritical.Test;

public class StringExtensionTests
{
	#region RemoveDiacritics tests

	[TestCase(null)]
	[TestCase("")]
	public void RemoveDiacritics_GivenNullOrEmpty_ThenReturnInitial(string input)
	{
		var result = input.RemoveDiacritics();

		Assert.Equals(input, result);
	}

	[TestCase("Hello")]
	[TestCase("ABCdef123")]
	[TestCase("!\"£$%^&*()_+")]
	public void RemoveDiacritics_GivenNoDiacritics_ThenReturnInitial(string input)
	{
		var result = input.RemoveDiacritics();

		Assert.Equals(input, result);
	}

	[TestCase("Fußball", "Fussball")]
	[TestCase("İngiltere", "Ingiltere")]
	public void RemoveDiacritics_GivenDiacritics_ThenReplace(string input, string expectedValue)
	{
		var result = input.RemoveDiacritics();

		Assert.Equals(expectedValue, result);
	}

	#endregion

	#region HasDiacritics tests

	[TestCase(null)]
	[TestCase("")]
	public void HasDiacritics_GivenNullOrEmpty_ThenReturnsFalse(string input)
	{
		var result = input.HasDiacritics();

		Assert.Equals(false, result);
	}

	[TestCase("Hello")]
	[TestCase("ABCdef123")]
	[TestCase("!\"£$%^&*()_+")]
	public void HasDiacritics_GivenNoDiacritics_ThenReturnsFalse(string input)
	{
		var result = input.HasDiacritics();

		Assert.Equals(false, result);
	}

	[TestCase("Fußball")]
	[TestCase("İngiltere")]
	public void HasDiacritics_GivenDiacritics_ThenReturnsTrue(string input)
	{
		var result = input.HasDiacritics();

		Assert.Equals(true, result);
	}

	#endregion

}