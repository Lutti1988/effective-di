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

		}
	}
}
