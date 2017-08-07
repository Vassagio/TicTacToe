using System.Collections.Generic;
using TicTacToe.Core.Game;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Game.States;
using TicTacToe.Core.Mocks.Game.Board;
using TicTacToe.Core.Mocks.Game.Service;
using TicTacToe.Core.Mocks.Game.States;
using Xunit;

namespace TicTacToe.Core.Tests.Game {
    public class TicTacToeGameTest {
        public static IEnumerable<object[]> AllStatesExceptEndState() {
            yield return new object[] {new CheckForWinGameState()};
            yield return new object[] {new PlayGameState()};
            yield return new object[] {new PlayAgainGameState()};
            yield return new object[] {new StartGameState()};
            yield return new object[] {new InitializeGameState()};
            yield return new object[] {new OverGameState()};
            yield return new object[] {new SwitchPlayerGameState()};
        }

        [Fact]
        public void Initialize() {
            var game = BuildGame();

            Assert.NotNull(game);
        }

        [Fact]
        public void Start_VerifyStateStartCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.Start();

            gameState.VerifyStartCalled();
        }

        [Fact]
        public void Over_VerifyStateOverCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.Over();

            gameState.VerifyOverCalled();
        }

        [Fact]
        public void End_VerifyStateEndCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.End();

            gameState.VerifyEndCalled();
        }

        [Fact]
        public void Play_VerifyStatePlayCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.Play();

            gameState.VerifyPlayCalled();
        }

        [Fact]
        public void CheckForWin_VerifyStateCheckForWinCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.CheckForWin();

            gameState.VerifyCheckForWinCalled();
        }

        [Fact]
        public void SwitchPlayer_VerifyStateSwitchPlayerCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.SwitchPlayer();

            gameState.VerifySwitchPlayerCalled();
        }

        [Fact]
        public void NewGame_VerifyStatePlayAgainCalled() {
            var gameState = new MockGameState();
            var game = BuildGame(gameState: gameState);

            game.PlayAgain();

            gameState.VerifyPlayAgainCalled();
        }

        [Theory]
        [MemberData(nameof(AllStatesExceptEndState))]
        public void StillGoing_ReturnTrueIfNotInEndState(IGameState gameState) {
            var game = BuildGame(gameState: gameState);

            var result = game.StillGoing;

            Assert.True(result);
        }

        [Fact]
        public void StillGoing_ReturnFalseIfInEndState() {
            var gameState = new EndGameState();
            var game = BuildGame(gameState: gameState);

            var result = game.StillGoing;

            Assert.False(result);
        }

        private static TicTacToeGame BuildGame(IBoard board = null, IGameService gameService = null, IGameState gameState = null) {
            board = board ?? new MockBoard();
            gameService = gameService ?? new MockGameService();
            gameState = gameState ?? new MockGameState();
            return new TicTacToeGame(board, gameService, gameState);
        }
    }
}