using Test.Utilities;
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
        public void Equal_SameComputerAreEqual()
        {
            var computer1 = BuildComputerPlayer();
            var computer2 = BuildComputerPlayer();

            EqualityTests.TestEqualObjects(computer1, computer2);
        }

        [Fact]
        public void Equal_ComputersWithDifferentNameAreNotEqual()
        {
            var computer1 = BuildComputerPlayer("Computer 1");
            var computer2 = BuildComputerPlayer("Computer 2");

            EqualityTests.TestUnequalObjects(computer1, computer2);
        }

        [Fact]
        public void Equal_ComputersWithDifferentSymbolAreNotEqual()
        {
            var computer1 = BuildComputerPlayer(symbol: "Symbol 1");
            var computer2 = BuildComputerPlayer(symbol: "Symbol 2");

            EqualityTests.TestUnequalObjects(computer1, computer2);
        }

        [Fact]
        public void Equal_ComputerCompareWithNull()
        {
            var computer1 = BuildComputerPlayer();

            EqualityTests.TestAgainstNull(computer1);
        }

        private static ComputerPlayer BuildComputerPlayer(string name = null, string symbol = null) {
            name = name ?? "Computer";
            symbol = symbol ?? "O";
            return new ComputerPlayer(name, symbol);
        }
    }
}
