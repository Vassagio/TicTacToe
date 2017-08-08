using Test.Utilities.ValueType;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player
{
    public class StartingPlayerTest
    {


        [Fact]
        public void First_Player_Equalalty_Tests()
        {
            var player1 = BuildStartingPlayerAsFirstPlayer();
            var player2 = BuildStartingPlayerAsFirstPlayer();
            var player3 = BuildStartingPlayerAsSecondPlayer();            

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different first player type")                         
                         .Assert();
        }

        [Fact]
        public void Second_Player_Equalalty_Tests()
        {
            var player1 = BuildStartingPlayerAsSecondPlayer();
            var player2 = BuildStartingPlayerAsSecondPlayer();
            var player3 = BuildStartingPlayerAsFirstPlayer();

            EqualityTests.For(player1)
                         .EqualTo(player1)
                         .EqualTo(player2)
                         .NotEqualTo(player3, "different second player type")
                         .Assert();
        }
      
        private static StartingPlayer BuildStartingPlayerAsFirstPlayer() => StartingPlayer.As().FirstPlayer();
        private static StartingPlayer BuildStartingPlayerAsSecondPlayer() => StartingPlayer.As().SecondPlayer();
    }
}
