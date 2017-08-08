using Test.Utilities;
using Test.Utilities.ValueType;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player
{
    public class ComputerPlayerTest
    {
        [Fact]
        public void Initialize()
        {
            var player = BuildComputerPlayer();

            Assert.NotNull(player);
        }

        [Fact]
        public void Initialize_SetsTheName() {
            const string NAME = "Computer Name";
            var player = BuildComputerPlayer(NAME);

            Assert.Equal(NAME, player.Name);
        }

        [Fact]
        public void Initialize_SetsTheSymbol() {
            const string SYMBOL = "#";
            var player = BuildComputerPlayer(symbol: SYMBOL);

            Assert.Equal(SYMBOL, player.Symbol);
        }

        [Fact]
        public void GetNextMove()
        {
            var player = BuildComputerPlayer();

            var move = player.GetNextMove();

            Assert.IsType<NoCoordinate>(move);
        }

        [Fact]
        public void Equalalty_Tests()
        {

            const string NAME = "Computer 1";
            const string DIFFERENT_NAME = "Computer 2";
            const string SYMBOL = "X";
            const string DIFFERENT_SYMBOL = "O";

            var player1 = BuildComputerPlayer(NAME, SYMBOL);
            var player2 = BuildComputerPlayer(NAME, SYMBOL);
            var player3 = BuildComputerPlayer(DIFFERENT_NAME, SYMBOL);
            var player4 = BuildComputerPlayer(NAME, DIFFERENT_SYMBOL);

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different name")
                         .NotEqualTo(player4, "different symbol")
                         .Assert();
        }      


        private static ComputerPlayer BuildComputerPlayer(string name = null, string symbol = null) {
            name = name ?? "Computer";
            symbol = symbol ?? "O";
            return new ComputerPlayer(name, symbol);
        }
    }
}
