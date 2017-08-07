using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Service {
    public class GameService : IGameService {
        private readonly IPlayers _players;

        public GameService(IPlayers players) => _players = players;

        public bool HasWinner() {
            return false;
        }

        public void MakeMove() {
            throw new System.NotImplementedException();
        }

        public void SwitchPlayer() {
            throw new System.NotImplementedException();
        }

        public bool PlayAgain() {
            throw new System.NotImplementedException();
        }
    }
}