using System;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using CroweHorwathAPI.Controllers;
using CroweHorwathBusinessLogic.Interface;
using CroweHorwathBusinessLogic.Utility;
using Moq;
using NUnit.Framework;


namespace CroweHorwathAPI.Test
{
	[TestFixture]
    public class HomeControllerTests
	{
		private HomeController _sut;
		private Mock<IMessageGenerator> _messageGenerator;
		private Mock<ILogger> _logger;
		[SetUp]
		public void SetUp()
		{
			 _messageGenerator= new Mock<IMessageGenerator>();
			 _logger=new Mock<ILogger>();
		}

		[Test]
		public void MessageExists()
		{
			_messageGenerator.Setup(x => x.GenerateWelcomeMessage()).Returns("Hello World");
			_sut = new HomeController(_messageGenerator.Object, _logger.Object);
			string result = _sut.GetBusinessMessage();
			Assert.AreEqual("Hello World", result);
			_logger.Verify(x => x.LogException(It.IsAny<Exception>()),Times.Never);
		}

		[Test]
		public void SqlExceptionIsThrown()
		{
			_messageGenerator.Setup(x => x.GenerateWelcomeMessage()).Throws(new SqlTypeException());
			_sut = new HomeController(_messageGenerator.Object, _logger.Object);
			string result = _sut.GetBusinessMessage();
			Assert.AreEqual("There was a Sql Exception thrown.", result);
			_logger.Verify(x => x.LogException(It.IsAny<SqlTypeException>()), Times.Once);
		}

		[Test]
		public void GenericExceptionIsThrown()
		{
			_messageGenerator.Setup(x => x.GenerateWelcomeMessage()).Throws(new Exception());
			_sut = new HomeController(_messageGenerator.Object, _logger.Object);
			string result = _sut.GetBusinessMessage();
			Assert.AreEqual("An error has occured. Please check the logs.", result);
			_logger.Verify(x => x.LogException(It.IsAny<Exception>()), Times.Once);
		}
	}
}
