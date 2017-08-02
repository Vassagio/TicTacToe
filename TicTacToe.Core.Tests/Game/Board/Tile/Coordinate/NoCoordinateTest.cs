using TicTacToe.Core.Game.Board.Tile.Coordinate;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Tile.Coordinate {
    public class NoCoordinateTest {
        [Fact]
        public void Initialize() {
            var coordinate = BuildNoCoordinate();

            Assert.IsAssignableFrom<ICoordinate>(coordinate);
        }

        [Fact]
        public void Initialize_X_ReturnsZero()
        {
            var coordinate = BuildNoCoordinate();

            Assert.Equal(0, coordinate.X);
        }

        [Fact]
        public void Initialize_Y_ReturnsZero()
        {
            var coordinate = BuildNoCoordinate();

            Assert.Equal(0, coordinate.Y);
        }

        private static NoCoordinate BuildNoCoordinate() => new NoCoordinate();
    }
}