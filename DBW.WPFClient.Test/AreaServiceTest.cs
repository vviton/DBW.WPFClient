using DBW.WPFClient.Services;

namespace DBW.WPFClient.Test
{
    public class AreaServiceTest
    {
        [Fact]
        public async Task Areaservice_Should_Return_Items()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            //Act
            var areas = await areaService.GetAreasAsync();
            //Assert
            Assert.True(areas.Count >0);
        }
        [Fact]
        public async Task GetAreasAsync_Returns()
        {
            // Arrange
            IAreaService areaService = new AreaService();
            //Act
            var areas = await areaService.GetAreasAsync();
            //Assert
            Assert.True(areas.Count > 0);
        }
    }
}