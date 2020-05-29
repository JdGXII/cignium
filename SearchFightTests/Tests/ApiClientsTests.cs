using FluentAssertions;
using NUnit.Framework;
using SearchFightTests.MockBuilders;
using SearchFightTests.MockBuilders.ClientMocks;
using Services.Services;
using System.Threading.Tasks;

namespace Tests
{
    public class ApiClientsTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task TestBingClientResults_ResultsOk()
        {
            //Arrange
            var bingMock = new BingMock();
            var service = new SearchService(new GoogleMock(), bingMock);
            service.SearchQueries = SearchServiceMock.BuildSearchQueries();

            //Act
            var actual = await service.PerformBingSearch();

            //Assert
            bingMock.ExpectedResults.Should().BeEquivalentTo(actual);
        }

        [Test]
        public async Task TestGoogleClientResults_ResultsOk()
        {
            //Arrange
            var googleMock = new GoogleMock();
            var service = new SearchService(googleMock, new BingMock());
            service.SearchQueries = SearchServiceMock.BuildSearchQueries();

            //Act
            var actual = await service.PerformGoogleSearch();

            //Assert
            googleMock.ExpectedResults.Should().BeEquivalentTo(actual);
        }
    }
}