using System;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Mocks.Game.Builder;
using TicTacToe.Core.Mocks.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Builder {
    public class StartingPlayerMapperTest {
        [Fact]
        public void Initialize() {
            var mapper = new StartingPlayerMapper();

            Assert.NotNull(mapper);
        }

        [Fact]
        public void Add_AddsANewStartingPlayer() {
            var startingPlayer = new MockStartingPlayer();
            var player = new MockPlayer();
            var mapper = new StartingPlayerMapper();

            var actual = mapper.Add(startingPlayer, player);

            Assert.Equal(player, actual[startingPlayer]);
        }

        [Fact]
        public void Add_AddMultipleWithDifferentKey_ThrowsArgumentException()
        {
            var startingPlayer1 = new MockStartingPlayer();
            var startingPlayer2 = new MockStartingPlayer();
            var player1 = new MockPlayer();
            var player2 = new MockPlayer();
            var mapper = new StartingPlayerMapper();

            var actual = mapper.Add(startingPlayer1, player1);
            actual = actual.Add(startingPlayer2, player2);

            Assert.Equal(player1, actual[startingPlayer1]);
            Assert.Equal(player2, actual[startingPlayer2]);
        }

        [Fact]
        public void Add_AddMultipleWithSameKey_ThrowsArgumentException()
        {
            var startingPlayer = new MockStartingPlayer();
            var player1 = new MockPlayer();
            var player2 = new MockPlayer();
            var mapper = new StartingPlayerMapper();

            var actual = mapper.Add(startingPlayer, player1);

            Assert.Throws<ArgumentException>(() => actual.Add(startingPlayer, player2));            
        }
    }
}