using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public interface IGameBuilderSetStartingPlayer{
        IGameBuilder Set(IStartingPlayer startingPlayer);        
    }
}