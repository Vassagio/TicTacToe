namespace TicTacToe.Core.Player
{
    public interface IPlayers
    {
        IPlayer Current { get; }    
        IPlayers Next();
        IPlayers Add(IPlayer player);
        IPlayers SetCurrentPlayer(IPlayer currentPlayer);
    }
}