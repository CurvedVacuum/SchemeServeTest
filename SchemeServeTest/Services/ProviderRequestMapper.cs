using SchemeServeTest.ServiceModel.Data;
using SchemeServeTestModel.Outgoing;

namespace SchemeServeTest.Service.Services
{
	public interface IProviderRequestMapper
	{
		Task<ProviderData> MapFromResponse(HttpResponseMessage data);
		Task<GetProvidersRequestResponse> MapResponseFromData(ProviderData providerData);
	}

	public class ProviderRequestMapper : IProviderRequestMapper
	{
		public Task<ProviderData> MapFromResponse(HttpResponseMessage data)
		{
			throw new NotImplementedException();
		}

		public Task<GetProvidersRequestResponse> MapResponseFromData(ProviderData providerData)
		{
			throw new NotImplementedException();
		}
	}
}
