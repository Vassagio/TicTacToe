using TicTacToe.Core.Game.Board.Tile.Coordinate;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Tile.Coordinate
{
    public class AvailableCoordinateTest
    {
        [Fact]
        public void Initialize()
        {
            var coordinate = BuildAvailableCoordinate();

            Assert.IsAssignableFrom<ICoordinate>(coordinate);
        }

        [Fact]
        public void Initialize_X_ReturnsX()
        {
            var coordinate = BuildAvailableCoordinate(x: 5);

            Assert.Equal(5, coordinate.X);
        }

        [Fact]
        public void Initialize_Y_ReturnsY()
        {
            var coordinate = BuildAvailableCoordinate(y: 11);

            Assert.Equal(11, coordinate.Y);
        }

        private static AvailableCoordinate BuildAvailableCoordinate(int? x = null, int? y = null) {
            x = x ?? 1;
            y = y ?? 1;
            
            return new AvailableCoordinate(x.Value, y.Value);
        } 
    }
}