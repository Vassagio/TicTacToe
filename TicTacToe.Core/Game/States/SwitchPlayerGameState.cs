using System;

namespace TicTacToe.Core.Game.States {
    internal class SwitchPlayerGameState : IGameState {
        public IGameState DeepClone() => new SwitchPlayerGameState();
        public IGameState Start() => this;
        public IGameState Play(Action makeMove) => this;
        public IGameState CheckForWin(Func<bool> hasWinner) => this;

        public IGameState SwitchPlayer(Action getNextPlayer) {
            getNextPlayer();
            return new PlayGameState();
        }

        public IGameState Over() => this;
        public IGameState PlayAgain(Func<bool> playAgain) => this;
        public IGameState End() => this;
    }
}