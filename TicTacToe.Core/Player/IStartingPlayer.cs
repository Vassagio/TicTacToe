namespace TicTacToe.Core.Player {
    public interface IStartingPlayer
    {
        StartingPlayer FirstPlayer();
        StartingPlayer SecondPlayer();
    }
}