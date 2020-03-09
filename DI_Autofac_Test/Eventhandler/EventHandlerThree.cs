using DI_Autofac_Test.Events;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Eventhandler
{
	public class EventHandlerThree : IEventHandler<SecondEvent>
	{
		public Task Handle(SecondEvent eventItem)
		{
			return Task.CompletedTask;
		}
	}
}
