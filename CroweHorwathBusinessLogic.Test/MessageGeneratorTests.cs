using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CroweHorwathBusinessLogic.Test
{
	[TestFixture]
	public class MessageGeneratorTests
	{
		private MessageGenerator _sut;
		[SetUp]
		public void SetUp()
		{
			_sut = new MessageGenerator();
		}
	
		[Test]
		public void ReturnCorrectMessageFromConfig()
		{
			string resultingValue = _sut.GenerateWelcomeMessage();
			Assert.AreEqual(resultingValue, "Default Message from the Test Project.");
		}
    }
}
