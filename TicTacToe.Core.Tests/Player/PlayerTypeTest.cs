using Test.Utilities;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player {
    public class PlayerTypeTest {
        [Fact]
        public void Player_HumanPlayerType() {
            var playerType = BuildPlayerTypeAsHuman();

            var player = playerType.Player;

            Assert.IsType<HumanPlayer>(player);
        }

        [Fact]
        public void Player_HumanPlayerType_SetsName()
        {
            const string NAME = "H";
            var playerType = BuildPlayerTypeAsHuman(NAME);

            var player = playerType.Player;

            Assert.Equal(NAME, player.Name);
        }

        [Fact]
        public void Player_HumanPlayerType_SetsSymbol()
        {
            const string SYMBOL = "H";
            var playerType = BuildPlayerTypeAsHuman(symbol: SYMBOL);

            var player = playerType.Player;

            Assert.Equal(SYMBOL, player.Symbol);
        }

        [Fact]
        public void Player_ComputerPlayerType()
        {
            var playerType = BuildPlayerTypeAsComputer();

            var player = playerType.Player;

            Assert.IsType<ComputerPlayer>(player);
        }

        [Fact]
        public void Player_ComputerPlayerType_SetsName()
        {
            const string NAME = "H";
            var playerType = BuildPlayerTypeAsComputer(NAME);

            var player = playerType.Player;

            Assert.Equal(NAME, player.Name);
        }

        [Fact]
        public void Player_ComputerPlayerType_SetsSymbol()
        {
            const string SYMBOL = "H";
            var playerType = BuildPlayerTypeAsComputer(symbol: SYMBOL);

            var player = playerType.Player;

            Assert.Equal(SYMBOL, player.Symbol);
        }

        [Fact]
        public void Equal_SameHumanAreEqual() {
            var playerType1 = BuildPlayerTypeAsHuman();
            var playerType2 = BuildPlayerTypeAsHuman();

            EqualityTests.TestEqualObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_HumansWithDifferentNameAreNotEqual()
        {
            var playerType1 = BuildPlayerTypeAsHuman("Human 1");
            var playerType2 = BuildPlayerTypeAsHuman("Human 2");

            EqualityTests.TestUnequalObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_HumansWithDifferentSymbolAreNotEqual()
        {
            var playerType1 = BuildPlayerTypeAsHuman(symbol: "Symbol 1");
            var playerType2 = BuildPlayerTypeAsHuman(symbol: "Symbol 2");

            EqualityTests.TestUnequalObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_HumanCompareWithNull()
        {
            var playerType1 = BuildPlayerTypeAsHuman();            

            EqualityTests.TestAgainstNull(playerType1);
        }

        [Fact]
        public void Equal_SameComputerAreEqual()
        {
            var playerType1 = BuildPlayerTypeAsComputer();
            var playerType2 = BuildPlayerTypeAsComputer();

            EqualityTests.TestEqualObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_ComputersWithDifferentNameAreNotEqual()
        {
            var playerType1 = BuildPlayerTypeAsComputer("Computer 1");
            var playerType2 = BuildPlayerTypeAsComputer("Computer 2");

            EqualityTests.TestUnequalObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_ComputersWithDifferentSymbolAreNotEqual()
        {
            var playerType1 = BuildPlayerTypeAsComputer(symbol: "Symbol 1");
            var playerType2 = BuildPlayerTypeAsComputer(symbol: "Symbol 2");

            EqualityTests.TestUnequalObjects(playerType1, playerType2);
        }

        [Fact]
        public void Equal_ComputerCompareWithNull()
        {
            var playerType1 = BuildPlayerTypeAsComputer();

            EqualityTests.TestAgainstNull(playerType1);
        }

        private static PlayerType BuildPlayerTypeAsHuman(string name = null, string symbol = null) {
            name = name ?? "Human Name";
            symbol = symbol ?? "Human Symbol";
            return PlayerType.As().Human(name, symbol);
        }

        private static PlayerType BuildPlayerTypeAsComputer(string name = null, string symbol = null)
        {
            name = name ?? "Computer Name";
            symbol = symbol ?? "Computer Symbol";
            return PlayerType.As().Computer(name, symbol);
        }
    }
}