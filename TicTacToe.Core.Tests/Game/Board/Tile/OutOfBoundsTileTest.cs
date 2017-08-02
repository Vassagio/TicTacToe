using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board.Tile {
    public class OutOfBoundsTileTest {
        [Fact]
        public void Initialize() {
            var tile = BuildOutOfBoundsTile();

            Assert.IsAssignableFrom<ITile>(tile);
        }

        [Fact]
        public void Initialize_SetsThePosition() {
            const int POSITION = 0;
            var tile = BuildOutOfBoundsTile();

            Assert.Equal(POSITION, tile.Position);
        }

        [Fact]
        public void Initialize_SetsTheCoordinate() {
            var tile = BuildOutOfBoundsTile();

            Assert.IsType<NoCoordinate>(tile.Coordinate);
        }

        [Fact]
        public void Player_AlwaysReturnsUnknownPlayer() {
            var tile = BuildOutOfBoundsTile();

            Assert.IsType<UnknownPlayer>(tile.Player);
        }

        [Fact]
        public void SetPlayer_ShouldNotSetPlayer() {
            var player = new MockPlayer();
            var tile = BuildOutOfBoundsTile();

            var actual = tile.SetPlayer(player);

            Assert.NotEqual(player, actual.Player);
        }

        private static OutOfBoundsTile BuildOutOfBoundsTile() => new OutOfBoundsTile();
    }
}