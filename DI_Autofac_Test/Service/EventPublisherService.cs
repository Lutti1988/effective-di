using Autofac;
using DI_Autofac_Test.Eventhandler;
using DI_Autofac_Test.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Service
{
	public class EventPublisherService : IEventPublisherService
	{
		private readonly IEnumerable<IEventHandler<IEvent>> _eventHandlers;

		public EventPublisherService(IContainer container)
		{
			Type ienumerableOfIEventHandlerType = typeof(IEnumerable<>).MakeGenericType(typeof(IEventHandler<>));
			IEnumerable<IEvent> eventHandler = container.Resolve(ienumerableOfIEventHandlerType) as IEnumerable<IEvent>;
			// The code line above results in the following error: 
			/* Autofac.Core.Registration.ComponentNotRegisteredException: 'The requested service '' has not been registered. 
			   To avoid this exception, either register a component to provide the service, check for service registration using IsRegistered(), 
			   or use the ResolveOptional() method to resolve an optional dependency. */


			/*
			Type generic = typeof(IEnumerable<IEventHandler<>>); // Unexpected use of an unbound generic 
			Type[] typeArgs = { typeof(IEvent) }; // TEvent is always a type of IEvent
			Type constructed = generic.MakeGenericType(typeArgs);

			_eventHandlers = container.Resolve(constructed);
			*/

		}

		public Task Emit(IEvent eventItem)
		{
			return Task.CompletedTask;
		}
	}
}
