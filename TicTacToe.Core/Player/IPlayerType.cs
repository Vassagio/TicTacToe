namespace TicTacToe.Core.Player {
    public interface IPlayerType {
        PlayerType Human(string name, string symbol);
        PlayerType Computer(string name, string symbol);
        IPlayer Player { get; }
    }
}