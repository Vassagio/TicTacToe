using System;
using System.Linq;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Player
{
    public class PlayersTest
    {
        [Fact]
        public void Initialize() {
            var players = new Players();

            Assert.NotNull(players);
        }

        [Fact]
        public void Count_WhenNoPlayersAdded_ReturnsZero() {
            var players = new Players();

            Assert.Equal(0, players.Count);
        }

        [Fact]
        public void Count_WhenOnePlayerAdded_ReturnsOne()
        {
            var players = new Players();
            players.Add(new MockPlayer());            

            Assert.Equal(1, players.Count);
        }

        [Fact]
        public void Count_WhenTwoPlayersAdded_ReturnsTwo()
        {
            var players = new Players();
            players.Add(new MockPlayer());
            players.Add(new MockPlayer());            

            Assert.Equal(2, players.Count);
        }

        [Fact]
        public void Add_WhenMoreThanTwoPlayersAdded_Throw() {
            var players = new Players();
            players.Add(new MockPlayer());
            players.Add(new MockPlayer());

            Assert.Throws<ArgumentException>(() => players.Add(new MockPlayer()));
        }

        [Fact]
        public void SetCurrentPlayer_WhenPlayerNotFound_ThrowsArgumentException() {
            var players = new Players();

            Assert.Throws<ArgumentException>(() => players.SetCurrentPlayer(new MockPlayer()));            
        }

        [Fact]
        public void SetCurrentPlayer_WhenPlayerFound()
        {
            var player = new MockPlayer();
            var players = new Players();
            players.Add(player);

            var actual = players.SetCurrentPlayer(player);

            Assert.Equal(player, actual.Current);
        }

        [Fact]
        public void SetCurrentPlayer_WhenPlayerFoundAmongstMultiplePlayers()
        {
            var player = new MockPlayer();
            var players = new Players();
            players.Add(new MockPlayer());
            players.Add(player);

            var actual = players.SetCurrentPlayer(player);

            Assert.Equal(player, actual.Current);
        }

        [Fact]
        public void Current_WhenInitialized_ReturnsUnknownPlayer()
        {
            var players = new Players();

            var player = players.Current;

            Assert.IsType<UnknownPlayer>(player);
        }

        [Fact]
        public void Next_WhenInitialized_ReturnsUnknownPlayer()
        {
            var players = new Players();

            var actual = players.Next();

            Assert.IsType<UnknownPlayer>(actual.Current);
        }

        [Fact]
        public void Next_WhenOnePlayerAndCurrentNotSet_ReturnsOnePlayer()
        {
            var player = new MockPlayer();
            var players = new Players();
            players.Add(player);

            var actual = players.Next();

            Assert.Equal(player, actual.Current);
        }

        [Fact]
        public void Next_WhenOnePlayerAndCurrentSetToPlayer_ReturnsOnePlayer()
        {
            var player = new MockPlayer();
            var players = new Players();
            players.Add(player);

            var actual = players.SetCurrentPlayer(player).Next();

            Assert.Equal(player, actual.Current);
        }

        [Fact]
        public void Next_WhenTwoPlayersAndCurrentSetToPlayer1_ReturnsPlayer2()
        {
            var player1 = new MockPlayer();
            var player2 = new MockPlayer();
            var players = new Players();
            players.Add(player1);
            players.Add(player2);

            var actual = players.SetCurrentPlayer(player1).Next();

            Assert.Equal(player2, actual.Current);
        }

        [Fact]
        public void Next_WhenTwoPlayersAndCurrentSetToPlayer2_ReturnsPlayer1()
        {
            var player1 = new MockPlayer();
            var player2 = new MockPlayer();
            var players = new Players();
            players.Add(player1);
            players.Add(player2);

            var actual = players.SetCurrentPlayer(player2).Next();

            Assert.Equal(player1, actual.Current);
        }        
    }
}
