using Microsoft.AspNetCore.Mvc;
using SchemeServeTest.Service.Services;
using SchemeServeTestModel.Incoming;

namespace SchemeServeTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProviderController : ControllerBase
	{
		private ILogger _logger;
		private readonly IProviderService _providerService;

		public ProviderController(ILogger logger, IProviderService providerService)
		{
			_logger = logger;
			_providerService = providerService;
		}

		[HttpGet(Name = "GetProviders")]
		public async Task<IActionResult> GetProviders([FromQuery] GetProvidersRequestParameters filters)
		{
			try
			{
				var response = await _providerService.GetProviders(filters);

				return Ok(response);
			}
			catch (Exception ex) 
			{
				string errorMessage = $"An unhandled exception occurred: {ex}";
				_logger.LogError(errorMessage);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		[HttpGet(Name = "GetProvider")]
		public async Task<IActionResult> GetProvider(string id)
		{
			try
			{
				var response = await _providerService.GetProvider(id);

				return Ok(response);
			}
			catch (Exception ex)
			{
				string errorMessage = $"An unhandled exception occurred: {ex}";
				_logger.LogError(errorMessage);

				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}
