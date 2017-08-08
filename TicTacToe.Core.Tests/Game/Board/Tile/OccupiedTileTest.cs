using Test.Utilities;
using Test.Utilities.ValueType;
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
        public void Equalalty_Tests()
        {
            const int POSITION = 1;
            const int DIFFERENT_POSITION = 2;
            var coordinate = new MockCoordinate();
            var differentCoordinate = new MockCoordinate();

            var tile1 = BuildOccupiedTile(POSITION, coordinate);
            var tile2 = BuildOccupiedTile(POSITION, coordinate);
            var tile3 = BuildOccupiedTile(DIFFERENT_POSITION, coordinate);
            var tile4 = BuildOccupiedTile(POSITION, differentCoordinate);

            EqualityTests.For(tile1)
                         .EqualTo(tile1)
                         .EqualTo(tile2)
                         .NotEqualTo(tile3, "different position")
                         .NotEqualTo(tile4, "different coordinate")                         
                         .Assert();
        }

        private static OccupiedTile BuildOccupiedTile(int? position = null, ICoordinate coordinate = null)
        {
            position = position ?? 1;
            coordinate = coordinate ?? new MockCoordinate();
            return new OccupiedTile(position.Value, coordinate);
        }
    }
}
