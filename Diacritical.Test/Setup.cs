using System.Collections.Generic;
using Diacritical.Test.Mock;
using NUnit.Framework;

namespace Diacritical.Test
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
