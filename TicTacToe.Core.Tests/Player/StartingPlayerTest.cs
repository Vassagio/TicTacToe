using Test.Utilities;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player
{
    public class StartingPlayerTest
    {

        [Fact]
        public void Equal_SameFirstPlayerAreEqual()
        {
            var firstPlayer1 = BuildStartingPlayerAsFirstPlayer();
            var firstPlayer2 = BuildStartingPlayerAsFirstPlayer();

            EqualityTests.TestEqualObjects(firstPlayer1, firstPlayer2);
        }

        [Fact]
        public void Equal_FirstPlayerCompareWithNull()
        {
            var firstPlayer = BuildStartingPlayerAsFirstPlayer();

            EqualityTests.TestAgainstNull(firstPlayer);
        }

        [Fact]
        public void Equal_SameSecondPlayerAreEqual()
        {
            var secondPlayer1 = BuildStartingPlayerAsSecondPlayer();
            var secondPlayer2 = BuildStartingPlayerAsSecondPlayer();

            EqualityTests.TestEqualObjects(secondPlayer1, secondPlayer2);
        }

        [Fact]
        public void Equal_SecondPlayerCompareWithNull()
        {
            var secondPlayer = BuildStartingPlayerAsSecondPlayer();

            EqualityTests.TestAgainstNull(secondPlayer);
        }

        [Fact]
        public void Equal_FirstPlayerNotEqualToSecondPlayer() {
            var firstPlayer = BuildStartingPlayerAsFirstPlayer();
            var secondPlayer = BuildStartingPlayerAsSecondPlayer();

            EqualityTests.TestUnequalObjects(firstPlayer, secondPlayer);
        }

        [Fact]
        public void Equal_SecondPlayerNotEqualToFirstPlayer()
        {
            var firstPlayer = BuildStartingPlayerAsFirstPlayer();
            var secondPlayer = BuildStartingPlayerAsSecondPlayer();

            EqualityTests.TestUnequalObjects(secondPlayer, firstPlayer);
        }

        private static StartingPlayer BuildStartingPlayerAsFirstPlayer() => StartingPlayer.As().FirstPlayer();
        private static StartingPlayer BuildStartingPlayerAsSecondPlayer() => StartingPlayer.As().SecondPlayer();
    }
}
