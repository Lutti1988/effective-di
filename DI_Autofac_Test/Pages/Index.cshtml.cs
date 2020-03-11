using System;
using DI_Autofac_Test.Events;
using DI_Autofac_Test.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DI_Autofac_Test.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly IEventPublisherService _eventPublisherService;

		public IndexModel(ILogger<IndexModel> logger, IEventPublisherService eventPublisherService)
		{
			_logger = logger;
			_eventPublisherService = eventPublisherService;
		}

		public void OnGet()
        {
            var event1 = new FirstEvent
            {
                MyID = Guid.NewGuid(),
                Timestamp = DateTime.Now
            };

            _eventPublisherService.Emit(event1);

            var event2 = new SecondEvent(new MyObject {ID = Guid.NewGuid(), Name = "Francesc"})
            {
                Timestamp = DateTime.Now
            };

            _eventPublisherService.Emit(event2);
        }
	}
}
