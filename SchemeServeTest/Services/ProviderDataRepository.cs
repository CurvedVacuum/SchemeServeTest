using SchemeServeTest.ServiceModel.Data;
using SchemeServeTestModel.Incoming;
using System.Diagnostics.CodeAnalysis;

namespace SchemeServeTest.ServiceServices
{
	public interface IProviderDataRepository
	{
		Task<int> AddProvider(ProviderData providerData);
		Task<IEnumerable<ProviderData>> GetProviders(GetProvidersRequestParameters filters);
	}

	[ExcludeFromCodeCoverage]
	public class ProviderDataRepository : IProviderDataRepository
	{
		private ILogger _logger;

		public ProviderDataRepository(ILogger logger)
		{
			_logger = logger;
		}

		public Task<int> AddProvider(ProviderData providerData)
		{
			// Write to DB but cache for 1 month in Redis
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProviderData>> GetProviders(GetProvidersRequestParameters filters)
		{
			// Write to DB but cache for 1 month in Redis
			throw new NotImplementedException();
		}
	}
}
