using DI_Autofac_Test.Events;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Eventhandler
{
	public interface IEventHandler<in TEvent> where TEvent : IEvent
	{
		Task Handle(TEvent eventItem);
	}
}
