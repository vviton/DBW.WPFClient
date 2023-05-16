using DBW.WPFClient.Converters;
using DBW.WPFClient.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Moq.Protected;
using System.Net;
using System.Reflection;

namespace DBWWPFClient.Test
{
    public class AreaServiceTest
    {
        private HttpClient _httpClient;
        [Fact]
        public async Task GetAreasAsync_Should_Return_NotEmpty_List()
        {
            // Arrange
            var areasJson = "[{\"id\":1,\"nazwa\":\"Ceny\",\"id-nadrzedny-elemment\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}]";
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(areasJson),
                });
            var httpClient = new HttpClient(handlerMock.Object);
            IAreaService areaService = new AreaService(httpClient);

            // Act
            var result = await areaService.GetAreasAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
        }
        [Fact]
        public async Task GetAreasAsync_Should_Return_List_With_Correct_Count_After_Successful_ApiCall()
        {
        var areasJson = "["+
    "  {\"id\":1,\"nazwa\":\"Ceny\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}," +
    "  {\"id\":4,\"nazwa\":\"Budownictwo\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}," +
    "  {\"id\":29,\"nazwa\":\"Finanse publiczne\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}," +
    "  {\"id\":32,\"nazwa\":\"Gospodarka morska i œródl¹dowa\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}\n" +
    "]";
            ConfigureHttpClientSendAsyncAndJsonResponse(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(areasJson),
            }, areasJson);
            IAreaService areaService = new AreaService(_httpClient);
            //Act
            var result = await areaService.GetAreasAsync();
            //Assert
            result.Should().HaveCount(4);
        }
        [Fact]
        public async Task Should_Return_Correct_FirstObject_From_GetAreasAsync()
        {
            var areasJson = "[{\"id\":1,\"nazwa\":\"Ceny\",\"id-nadrzedny-element\":727,\"id-poziom\":1,\"nazwa-poziom\":\"Dziedzina\",\"czy-zmienne\":false}]";
            ConfigureHttpClientSendAsyncAndJsonResponse(new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(areasJson),
            },
            areasJson);
            IAreaService areaService = new AreaService(_httpClient);
            var apiCallResult = await areaService.GetAreasAsync();
            var firstObject = apiCallResult[0];

            using (new AssertionScope())
            {
                firstObject.Id.Should().Be(1);
                firstObject.Name.Should().Be("Ceny");
                firstObject.ParentId.Should().Be(727);
                firstObject.LevelId.Should().Be(1);
                firstObject.LevelName.Should().Be("Dziedzina");
                firstObject.Changeable.Should().BeFalse();
            }
        }
        [Fact]
        public async Task GetAreasAsync_Should_Return_Empty_List_When_ApiCall_Fails()
        {
            // Arrange
            ConfigureHttpClientSendAsync(
                new HttpResponseMessage
                {
                  StatusCode = HttpStatusCode.InternalServerError 
                }
                );

            var areaService = new AreaService(_httpClient);
            // Act
            var result = await areaService.GetAreasAsync();

            // Assert
            result.Should().BeEmpty();
        }
        private void ConfigureHttpClientSendAsyncAndJsonResponse(HttpResponseMessage message, string json)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(message);
             _httpClient = new HttpClient(handlerMock.Object);
        }
        private void ConfigureHttpClientSendAsync(HttpResponseMessage message)
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(message);
            _httpClient = new HttpClient(handlerMock.Object);
        }
    }

}