using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player {
    public class UnknownPlayerTest {
        [Fact]
        public void Initialize() {
            var player = new UnknownPlayer();

            Assert.NotNull(player);
        }

        [Fact]
        public void GetNextMove_ReturnsNoCoordinate() {
            var player = new UnknownPlayer();

            var nextMove = player.GetNextMove();

            Assert.IsType<NoCoordinate>(nextMove);
        }

        [Fact]
        public void Initialize_DefaultsTheNameToEmpty() {
            var player = new UnknownPlayer();

            Assert.Empty(player.Name);
        }

        [Fact]
        public void Initialize_DefaultsTheSymbolToEmpty() {
            var player = new UnknownPlayer();

            Assert.Empty(player.Symbol);
        }
    }
}