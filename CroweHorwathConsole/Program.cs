using System;
using CroweHorwathAPI.Controllers;

namespace CroweHorwathConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			HomeController controller = new HomeController();

			//Note:	This is not typically how you would call an API
			//		But it does function as a WebAPI.
			string message = controller.GetBusinessMessage();
			Console.WriteLine(message);

			Console.ReadKey();
		}
	}
}
