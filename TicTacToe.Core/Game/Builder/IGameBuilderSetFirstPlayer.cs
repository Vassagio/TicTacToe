using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public interface IGameBuilderSetFirstPlayer {
        IGameBuilderSetSecondPlayer FirstPlayerSet(IPlayerType playerType);
    }
}