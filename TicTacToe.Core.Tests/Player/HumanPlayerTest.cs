using Test.Utilities;
using Test.Utilities.ValueType;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player {
    public class HumanPlayerTest {
        [Fact]
        public void Initialize() {
            var player = BuildHumanPlayer();

            Assert.NotNull(player);
        }

        [Fact]
        public void Initialize_SetsTheName() {
            const string NAME = "Player Name";
            var player = BuildHumanPlayer(NAME);

            Assert.Equal(NAME, player.Name);
        }

        [Fact]
        public void Initialize_SetsTheSymbol() {
            const string SYMBOL = "$";
            var player = BuildHumanPlayer(symbol: SYMBOL);

            Assert.Equal(SYMBOL, player.Symbol);
        }

        [Fact]
        public void GetNextMove()
        {
            var player = BuildHumanPlayer();

            var move = player.GetNextMove();

            Assert.IsType<NoCoordinate>(move);
        }

        [Fact]
        public void Equalalty_Tests()
        {

            const string NAME = "Human 1";
            const string DIFFERENT_NAME = "Human 2";
            const string SYMBOL = "X";
            const string DIFFERENT_SYMBOL = "O";

            var player1 = BuildHumanPlayer(NAME, SYMBOL);
            var player2 = BuildHumanPlayer(NAME, SYMBOL);
            var player3 = BuildHumanPlayer(DIFFERENT_NAME, SYMBOL);
            var player4 = BuildHumanPlayer(NAME, DIFFERENT_SYMBOL);            

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different name")
                         .NotEqualTo(player4, "different symbol")                         
                         .Assert();
        }

        private static HumanPlayer BuildHumanPlayer(string name = null, string symbol = null) {
            name = name ?? "Human";
            symbol = symbol ?? "X";
            return new HumanPlayer(name, symbol);
        }
    }
}