namespace TicTacToe.Core.Game.Service {
    internal interface IGameService {
        bool HasWinner();
    }

    class GameService : IGameService {
        public bool HasWinner() {
            return false;
        }
    }
}