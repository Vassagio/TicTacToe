using Test.Utilities;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Tile
{
    public class OccupiedTileTest
    {
        [Fact]
        public void Initialize()
        {
            var tile = BuildOccupiedTile();

            Assert.IsAssignableFrom<ITile>(tile);
        }

        [Fact]
        public void Initialize_SetsThePosition()
        {
            const int POSITION = 20;
            var tile = BuildOccupiedTile(POSITION);

            Assert.Equal(POSITION, tile.Position);
        }

        [Fact]
        public void Initialize_SetsTheCoordinate()
        {
            var coordinate = new MockCoordinate();
            var tile = BuildOccupiedTile(coordinate: coordinate);

            Assert.Equal(coordinate, tile.Coordinate);
        }

        [Fact]
        public void Initialize_AlwaysReturnsUnknownPlayer()
        {
            var tile = BuildOccupiedTile();

            Assert.IsType<UnknownPlayer>(tile.Player);
        }

        [Fact]
        public void SetPlayer_ShouldSetPlayer()
        {
            var player = new MockPlayer();
            var tile = BuildOccupiedTile();

            var actual = tile.SetPlayer(player);

            Assert.Equal(player, actual.Player);
        }

        [Fact]
        public void Equal_SameTilesAreEqual()
        {
            var coordinate = new MockCoordinate();
            var tile1 = BuildOccupiedTile(coordinate: coordinate);
            var tile2 = BuildOccupiedTile(coordinate: coordinate);

            EqualityTests.TestEqualObjects(tile1, tile2);
        }

        [Fact]
        public void Equal_TilesWithDifferentPositionsAreNotEqual()
        {
            var coordinate = new MockCoordinate();
            var tile1 = BuildOccupiedTile(1, coordinate);
            var tile2 = BuildOccupiedTile(2, coordinate);

            EqualityTests.TestUnequalObjects(tile1, tile2);
        }

        [Fact]
        public void Equal_TilesWithDifferentCoordinatesAreNotEqual()
        {
            var tile1 = BuildOccupiedTile(coordinate: new MockCoordinate());
            var tile2 = BuildOccupiedTile(coordinate: new MockCoordinate());

            EqualityTests.TestUnequalObjects(tile1, tile2);
        }

        [Fact]
        public void Equal_ComputerCompareWithNull()
        {
            var tile1 = BuildOccupiedTile();

            EqualityTests.TestAgainstNull(tile1);
        }

        private static OccupiedTile BuildOccupiedTile(int? position = null, ICoordinate coordinate = null)
        {
            position = position ?? 1;
            coordinate = coordinate ?? new MockCoordinate();
            return new OccupiedTile(position.Value, coordinate);
        }
    }
}
