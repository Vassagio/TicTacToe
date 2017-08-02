using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public interface IGameBuilderSetSecondPlayer
    {
        IGameBuilderSetStartingPlayer SecondPlayerSet(IPlayerTypeCreate playerType);        
    }
}