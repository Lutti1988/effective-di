using System;

namespace DI_Autofac_Test.Events
{
	public interface IEvent
	{
		public DateTime Timestamp { get; set; }
	}
}
