using System.Configuration;
using CroweHorwathBusinessLogic.Interface;

namespace CroweHorwathBusinessLogic
{
	public class MessageGenerator:IMessageGenerator
	{
		public string GenerateWelcomeMessage()
		{	
			string message= ConfigurationManager.AppSettings[AppSettingKeys.WelcomeMessage];
			return message;
		}
	}
}
