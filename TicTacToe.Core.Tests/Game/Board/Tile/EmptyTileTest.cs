using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Tile
{
    public class EmptyTileTest
    {
        [Fact]
        public void Initialize() {
            var tile = BuildEmptyTile();

            Assert.IsAssignableFrom<ITile>(tile);
        }
        
        [Fact]
        public void Initialize_SetsThePosition()
        {
            const int POSITION = 20;
            var tile = BuildEmptyTile(POSITION);

            Assert.Equal(POSITION, tile.Position);
        }

        [Fact]        
        public void Initialize_SetsTheCoordinate()
        {
            var coordinate = new MockCoordinate();
            var tile = BuildEmptyTile(coordinate: coordinate);

            Assert.Equal(coordinate, tile.Coordinate);
        }

        [Fact]
        public void Player_AlwaysReturnsUnknownPlayer()
        {
            var tile = BuildEmptyTile();
            
            Assert.IsType<UnknownPlayer>(tile.Player);
        }

        [Fact]
        public void SetPlayer_ShouldNotSetPlayer()
        {
            var player = new MockPlayer();
            var tile = BuildEmptyTile();

            var actual = tile.SetPlayer(player);

            Assert.NotEqual(player, actual.Player);
        }

        private static EmptyTile BuildEmptyTile(int? position = null, ICoordinate coordinate = null) {
            position = position ?? 1;
            coordinate = coordinate ?? new MockCoordinate();
            return new EmptyTile(position.Value, coordinate);
        }
    }
}
