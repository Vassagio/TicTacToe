using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Visitor {
    public interface IGameVisitor {
        void Execute(IBoard board, IPlayers players);
    }
}