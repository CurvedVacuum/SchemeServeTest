using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using SchemeServeTest.Controllers;
using SchemeServeTest.Service.Services;
using SchemeServeTestModel.Incoming;
using System.Collections;
using Xunit;

namespace SchemeServeTest.Service.Tests
{
	public class ProviderControllerTests
	{
		private readonly ProviderController _providerController;
		private Mock<IProviderService> _providerServiceMock;
		private Mock<ILogger> _loggerMock;

		public ProviderControllerTests()
		{
			_providerServiceMock = new Mock<IProviderService>();
			_loggerMock = new Mock<ILogger>();

			_providerController = new ProviderController(_loggerMock.Object, _providerServiceMock.Object);
		}

		[Theory]
		[InlineData("1-345678912", @"
{
""providerId"": ""1-345678912"", 
""locationIds"": [ 
 ""1-987654321"", 
 ""1-876543212"" 
], 
""organisationType"": ""Provider"", 
""ownershipType"": ""NHS Body"",  
""type"": ""NHS Healthcare Organisation"", 
""name"": ""Sample Teaching Hospitals NHS Foundation Trust"",  
""brandId"": ""ABC123"", 
""brandName"": ""Sample Hill"",  
""registrationStatus"": ""Registered"", 
""registrationDate"": ""2012-04-01"", 
""companiesHouseNumber"": ""12345678"",  
""charityNumber"": ""123456"", 
""website"": ""www.samplehospitals.nhs.uk"", 
""postalAddressLine1"": ""Trust Headquarters, Example Hospital"", 
“postalAddressLine2"": ""Example Road"",
“postalAddressTownCity"": ""Blackpool"", 
""postalAddressCounty"": ""Lancashire"", 
""region"": ""North West"", s
""postalCode"": ""FY3 8RN"", 
""uprn"": ""123456789012"", 
""onspdLatitude"": 53.123456, 
""onspdLongitude"": -2.123456, 
""mainPhoneNumber"": ""01253301234"", 
""inspectionDirectorate"": ""Hospitals"", 
""constituency"": ""Blackpool North and Cleveleys"", 
""localAuthority"": ""Blackpool"", 
""lastInspection"": { 
 ""date"": ""2021-11-01"" 
}")]
		public async Task GetProvider_Should_ReturnProviderDetailsAndSave(string requestId, string expectedResponse)
		{
			// Arrange
			// # Set up dependency behaviours here
			
			// Act
			var result = await _providerController.GetProvider(requestId);

			// Assert
			result.Should().BeEquivalentTo(expectedResponse);
		}

		[Theory]
		[ClassData(typeof(GetProvidersTestData))]
		public async Task GetProviders_Should_ReturnListOfProvidersAndSave(GetProvidersRequestParameters request, string expectedResponse)
		{
			// Arrange
			// # Set up dependency behaviours here

			// Act
			var result = await _providerController.GetProviders(request);

			// Assert
			result.Should().BeEquivalentTo(expectedResponse);
		}

		public class GetProvidersTestData : IEnumerable<object[]>
		{
			public IEnumerator<object[]> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}
