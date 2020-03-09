using DI_Autofac_Test.Eventhandler;
using DI_Autofac_Test.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Service
{
	public class EventPublisherService : IEventPublisherService
	{
		private readonly IEnumerable<IEventHandler<IEvent>> _eventHandlers;

		public EventPublisherService(IEnumerable<IEventHandler<IEvent>> eventHandlers)
		{
			_eventHandlers = eventHandlers;
		}

		public Task Emit(IEvent eventItem)
		{
			return Task.CompletedTask;
		}
	}
}
