using Autofac;
using DI_Autofac_Test.Eventhandler;
using DI_Autofac_Test.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Service
{
	public class EventPublisherService : IEventPublisherService
	{
        private readonly ILifetimeScope _lifetimeScope;

		public EventPublisherService(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

		public async Task Emit(IEvent eventItem)
		{
            Type[] typeArgs = { eventItem.GetType() };
            Type handlerType = typeof(IEventHandler<>).MakeGenericType(typeArgs);
			Type handlerCollectionType = typeof(IEnumerable<>).MakeGenericType(handlerType);
			
			var handlers = (IEnumerable<object>)_lifetimeScope.Resolve(handlerCollectionType);

            var handleMethod = handlerType.GetMethod("Handle");
			
			foreach (object handler in handlers)
			{
				await ((Task)handleMethod.Invoke(handler, new object[] { eventItem }));
			}
        }
	}
}
