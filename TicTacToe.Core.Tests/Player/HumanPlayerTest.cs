using Test.Utilities;
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
        public void Equal_SameHumanAreEqual()
        {
            var human1 = BuildHumanPlayer();
            var human2 = BuildHumanPlayer();

            EqualityTests.TestEqualObjects(human1, human2);
        }

        [Fact]
        public void Equal_HumansWithDifferentNameAreNotEqual()
        {
            var human1 = BuildHumanPlayer("Human 1");
            var human2 = BuildHumanPlayer("Human 2");

            EqualityTests.TestUnequalObjects(human1, human2);
        }

        [Fact]
        public void Equal_HumansWithDifferentSymbolAreNotEqual()
        {
            var human1 = BuildHumanPlayer(symbol: "Symbol 1");
            var human2 = BuildHumanPlayer(symbol: "Symbol 2");

            EqualityTests.TestUnequalObjects(human1, human2);
        }

        [Fact]
        public void Equal_HumanCompareWithNull()
        {
            var human1 = BuildHumanPlayer();

            EqualityTests.TestAgainstNull(human1);
        }

        private static HumanPlayer BuildHumanPlayer(string name = null, string symbol = null) {
            name = name ?? "Human";
            symbol = symbol ?? "X";
            return new HumanPlayer(name, symbol);
        }
    }
}