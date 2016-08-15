using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.Http;
using CroweHorwathBusinessLogic;
using CroweHorwathBusinessLogic.Interface;
using CroweHorwathBusinessLogic.Utility;

namespace CroweHorwathAPI.Controllers
{
	public class HomeController : ApiController
	{
		private IMessageGenerator _messageGenerator;
		private ILogger _logger;

		public HomeController() : this(new MessageGenerator(), new Logger())
		{
			
		}

		public HomeController(IMessageGenerator messageGenerator, ILogger logger)
		{
			_messageGenerator = messageGenerator;
			_logger = logger;
		}

		public string GetBusinessMessage()
		{
			string returnMessage;
			try
			{
				returnMessage = _messageGenerator.GenerateWelcomeMessage();
			}
			catch (SqlTypeException ex)
			{
				//Note:	No, we're not using anything that will cause a SqlTypeException,
				//		but this is just an example.
				_logger.LogException(ex);
				returnMessage = "There was a Sql Exception thrown.";
			}
			catch (Exception ex)
			{
				_logger.LogException(ex);
				//Note:	There's a number of better messages, but let's 
				//		just go with simplicity.
				returnMessage = "An error has occured. Please check the logs.";
			}
			return returnMessage;
		}
	}
}
