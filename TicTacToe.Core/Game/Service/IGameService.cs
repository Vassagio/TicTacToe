namespace TicTacToe.Core.Game.Service {
    public interface IGameService {
        bool HasWinner();
        void MakeMove();
        void SwitchPlayer();
        bool PlayAgain();
    }
}