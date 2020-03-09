using System;

namespace DI_Autofac_Test.Events
{
	public class BaseEvent : IEvent
	{
		public DateTime Timestamp { get; set; }
		public BaseEvent()
		{
			Timestamp = DateTime.Now;
		}
	}
}
