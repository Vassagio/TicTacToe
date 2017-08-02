using System;

namespace TicTacToe.Core.Game.States {
    class PlayGameState : IGameState {
        public IGameState Start() => this;
        public IGameState Play(Action makeMove) => new CheckForWinGameState();
        public IGameState CheckForWin(Func<bool> hasWinner) => this;
        public IGameState SwitchPlayer(Action getNextPlayer) => this;
        public IGameState Over() => this;
        public IGameState PlayAgain(Func<bool> playAgain) => this;
        public IGameState End() => this;
    }
}