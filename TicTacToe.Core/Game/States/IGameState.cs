using System;

namespace TicTacToe.Core.Game.States {
    public interface IGameState {
        IGameState Start();
        IGameState Play(Action makeMove);
        IGameState CheckForWin(Func<bool> hasWinner);
        IGameState SwitchPlayer(Action getNextPlayer);
        IGameState Over();
        IGameState PlayAgain(Func<bool> playAgain);
        IGameState End();
    }
}