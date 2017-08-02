namespace TicTacToe.Core.Player {
    public interface IPlayerType {
        IPlayerTypeCreate Human(string name, string symbol);
        IPlayerTypeCreate Computer(string name, string symbol);
    }
}