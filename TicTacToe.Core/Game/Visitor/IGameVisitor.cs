using TicTacToe.Core.Game.Board;

namespace TicTacToe.Core.Game.Visitor {
    public interface IGameVisitor {
        void Execute(IBoard board);
    }
}