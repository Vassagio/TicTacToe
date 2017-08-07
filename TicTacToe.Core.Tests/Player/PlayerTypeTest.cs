using Test.Utilities;
using Test.Utilities.ValueType;
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
        public void Human_Equalalty_Tests()
        {

            const string NAME = "Human 1";
            const string DIFFERENT_NAME = "Human 2";
            const string SYMBOL = "X";
            const string DIFFERENT_SYMBOL = "O";

            var player1 = BuildPlayerTypeAsHuman(NAME, SYMBOL);
            var player2 = BuildPlayerTypeAsHuman(NAME, SYMBOL);
            var player3 = BuildPlayerTypeAsHuman(DIFFERENT_NAME, SYMBOL);
            var player4 = BuildPlayerTypeAsHuman(NAME, DIFFERENT_SYMBOL);
            var player5 = BuildPlayerTypeAsComputer(NAME, SYMBOL);

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different name")
                         .NotEqualTo(player4, "different symbol")
                         .NotEqualTo(player5, "different type")
                         .Assert();
        }

        [Fact]
        public void Computer_Equalalty_Tests()
        {

            const string NAME = "Computer 1";
            const string DIFFERENT_NAME = "Computer 2";
            const string SYMBOL = "X";
            const string DIFFERENT_SYMBOL = "O";

            var player1 = BuildPlayerTypeAsComputer(NAME, SYMBOL);
            var player2 = BuildPlayerTypeAsComputer(NAME, SYMBOL);
            var player3 = BuildPlayerTypeAsComputer(DIFFERENT_NAME, SYMBOL);
            var player4 = BuildPlayerTypeAsComputer(NAME, DIFFERENT_SYMBOL);
            var player5 = BuildPlayerTypeAsHuman(NAME, SYMBOL);

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different name")
                         .NotEqualTo(player4, "different symbol")
                         .NotEqualTo(player5, "different type")
                         .Assert();
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