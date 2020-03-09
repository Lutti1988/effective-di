using DI_Autofac_Test.Events;
using System.Threading.Tasks;

namespace DI_Autofac_Test.Service
{
	public interface IEventPublisherService
	{
		public Task Emit(IEvent eventItem);

	}
}
