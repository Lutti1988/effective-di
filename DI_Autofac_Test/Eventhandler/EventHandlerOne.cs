using DI_Autofac_Test.Events;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Eventhandler
{
	public class EventHandlerOne : IEventHandler<FirstEvent>
	{
		public Task Handle(FirstEvent eventItem)
		{
			return Task.CompletedTask;
		}
	}
}
