using System.Collections.Generic;
using Diacritical.Test.Mock;
using NUnit.Framework;

namespace Diacritical.Test;

[SetUpFixture]
public class DiacriticalSetup
{
	[OneTimeSetUp]
	public void RunBeforeAnyTests()
	{
		DiacriticMap.AddProviders(new CustomDiacriticProvider(new Dictionary<char, string>
		{
			{ '@', "[at]" }
		}));
	}

	[OneTimeTearDown]
	public void RunAfterAnyTests()
	{
	}
}