using System;

namespace TicTacToe.Core.Game.States {
    internal class PlayAgainGameState : IGameState {
        public IGameState DeepClone() => new PlayAgainGameState();
        public IGameState Start() => this;
        public IGameState Play(Action makeMove) => this;
        public IGameState CheckForWin(Func<bool> hasWinner) => this;
        public IGameState SwitchPlayer(Action getNextPlayer) => this;
        public IGameState Over() => this;

        public IGameState PlayAgain(Func<bool> playAgain) {
            if (playAgain())
                return new StartGameState();
            return new EndGameState();
        }

        public IGameState End() => this;
    }
}