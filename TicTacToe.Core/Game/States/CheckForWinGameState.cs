using System;

namespace TicTacToe.Core.Game.States {
    internal class CheckForWinGameState : IGameState {
        public IGameState Start() => this;
        public IGameState Play(Action makeMove) => this;
        public IGameState CheckForWin(Func<bool> hasWinner) {
            if (hasWinner())
                return new OverGameState();
            return new SwitchPlayerGameState();
        }
        public IGameState SwitchPlayer(Action getNextPlayer) => this;
        public IGameState Over() => this;
        public IGameState PlayAgain(Func<bool> playAgain) => this;
        public IGameState End() => this;
    }
}