using System;

namespace CroweHorwathBusinessLogic.Utility
{
	public class Logger:ILogger
	{
		public void LogException(Exception ex)
		{
			//Note: There's a number of ways to do logging
			//		using things like Log4Net or Serilog,
			//		but we're going to keep it simple.
		}
	}
}
