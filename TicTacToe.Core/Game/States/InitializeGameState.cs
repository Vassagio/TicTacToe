using System;

namespace TicTacToe.Core.Game.States {
    public class InitializeGameState : IGameState {
        public IGameState Start() => new StartGameState();
        public IGameState Play(Action makeMove) => this;
        public IGameState CheckForWin(Func<bool> hasWinner) => this;
        public IGameState SwitchPlayer(Action getNextPlayer) => this;
        public IGameState Over() => this;
        public IGameState PlayAgain(Func<bool> playAgain) => this;
        public IGameState End() => this;
    }
}