using System.Linq;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Board.Tile;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Service
{
    public class BoardServiceTest
    {
        [Fact]
        public void Initialize() {
            var service = new BoardService();

            Assert.IsAssignableFrom<IBoardService>(service);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 9)]
        [InlineData(5, 25)]
        public void GenerateTilesWithCoordinates_ReturnsXxXNumberOfTiles(int size, int numberOfTiles)
        {
            var service = new BoardService();

            var tiles = service.GenerateTilesWithCoordinates(size);

            Assert.Equal(numberOfTiles, tiles.Count());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]        
        public void GenerateTilesWithCoordinates_WithSizeLessThanOrEqualToZero_ReturnsEmptyList(int size)
        {
            var service = new BoardService();

            var tiles = service.GenerateTilesWithCoordinates(size);

            Assert.Empty(tiles);
        }

        [Fact]        
        public void GenerateTilesWithCoordinates_WithSize1_SetsCorrectPositionAndCoordinates()
        {
            var service = new BoardService();

            var tiles = service.GenerateTilesWithCoordinates(1).ToList();

            AssertPositionAndCoordinate(tiles[0], 1, 1, 1);
        }

        [Fact]
        public void GenerateTilesWithCoordinates_WithSize2_SetsCorrectPositionAndCoordinates()
        {
            var service = new BoardService();

            var tiles = service.GenerateTilesWithCoordinates(2).ToList();

            AssertPositionAndCoordinate(tiles[0], 1, 1, 1);
            AssertPositionAndCoordinate(tiles[1], 2, 2, 1);
            AssertPositionAndCoordinate(tiles[2], 3, 1, 2);
            AssertPositionAndCoordinate(tiles[3], 4, 2, 2);
        }

        private static void AssertPositionAndCoordinate(ITile tile, int position, int x, int y) {
            Assert.Equal(position, tile.Position);
            Assert.Equal(x, tile.Coordinate.X);
            Assert.Equal(y, tile.Coordinate.Y);
        }
    }
}
