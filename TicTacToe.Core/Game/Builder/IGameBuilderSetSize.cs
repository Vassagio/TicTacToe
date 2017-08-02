namespace TicTacToe.Core.Game.Builder {
    public interface IGameBuilderSetSize {
        IGameBuilderSetFirstPlayer WithBoardSize(int size);
    }
}