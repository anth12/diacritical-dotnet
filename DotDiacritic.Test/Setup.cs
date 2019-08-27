using System.Collections.Generic;
using DotDiacritic.Test.Mock;
using NUnit.Framework;

namespace DotDiacritic.Test
{
	[SetUpFixture]
	public class MyClass
	{
		[OneTimeSetUp]
		public void RunBeforeAnyTests()
		{
			DiacriticMap.AddProvider(new CustomDiacriticProvider(new Dictionary<char, string>
			{
				{ '@', "[at]" }
			}));
		}

		[OneTimeTearDown]
		public void RunAfterAnyTests()
		{
		}
	}
}
