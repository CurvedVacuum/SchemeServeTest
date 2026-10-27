using SchemeServeTest.ServiceModel.Data;
using SchemeServeTest.ServiceServices;
using SchemeServeTestModel.Incoming;
using SchemeServeTestModel.Outgoing;

namespace SchemeServeTest.Service.Services
{
	public interface IProviderService
	{
		Task<GetProvidersRequestResponse> GetProvider(string id);

		Task<IEnumerable<GetProvidersRequestResponse>> GetProviders(GetProvidersRequestParameters filters);
	}

	public class ProviderService : IProviderService
	{
		private readonly IProviderDataRepository _providerDataRepository;

		private readonly IHttpClientFactory _httpClientFactory;

		private readonly IProviderRequestMapper _providerRequestMapper;

		private const string CLIENT_ROOT = "https://api.service.cqc.org.uk/public/v1/";


		public ProviderService(IProviderDataRepository providerDataRepository, IHttpClientFactory httpClientFactory, IProviderRequestMapper providerRequestMapper)
		{
			_providerDataRepository = providerDataRepository;
			_httpClientFactory = httpClientFactory;
			_providerRequestMapper = providerRequestMapper;
		}

		public async Task<GetProvidersRequestResponse> GetProvider(string id)
		{
			HttpClient client = _httpClientFactory.CreateClient();

			using HttpRequestMessage httpRequest = new(HttpMethod.Get, $"{CLIENT_ROOT}\\providers\\{id})");

			httpRequest.Headers.Add("Ocp-Apim-Subscription-Key", "65907e17e06440f6b212ded670f54cbb");

			HttpResponseMessage httpResponse = await client.SendAsync(httpRequest);

			ProviderData providerData = await _providerRequestMapper.MapFromResponse(httpResponse);

			// ran out of time here..!

			int errorCode = await _providerDataRepository.AddProvider(providerData);

			return await _providerRequestMapper.MapResponseFromData(providerData);
		}

		public async Task<IEnumerable<GetProvidersRequestResponse>> GetProviders(GetProvidersRequestParameters filters)
		{
			throw new NotImplementedException();
		}
	}
}
