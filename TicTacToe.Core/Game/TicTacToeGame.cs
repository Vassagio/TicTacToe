using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Game.States;
using TicTacToe.Core.Game.Visitor;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game {
    public class TicTacToeGame {
        private TicTacToeBoard _board;
        private IPlayers _players;
        private readonly IGameService _gameService;
        private IGameState _gameState = new InitializeGameState();

        internal TicTacToeGame(TicTacToeBoard board, IPlayers players, IGameService gameService) {
            _board = board;
            _players = players;
            _gameService = gameService;
        }

        public bool StillGoing => !(_gameState is EndGameState);

        public void Start() {
            _gameState = _gameState.Start();
        }

        public void Play() {
            _gameState = _gameState.Play(MakeMove);
        }

        private void MakeMove() {
            var coordinate = _players.Current.GetNextMove();
            _board = _board.SetTile(coordinate, _players.Current);
        }

        public void CheckForWin() {
            _gameState = _gameState.CheckForWin(HasWinner);
        }

        private bool HasWinner() {
            return _gameService.HasWinner();
        }

        public void SwitchPlayer() {
            _gameState = _gameState.SwitchPlayer(GetNextPlayer);           
        }

        private void GetNextPlayer() {
            _players = _players.Next();
        }

        public void Over() {
            _gameState = _gameState.Over();
        }

        public void NewGame()
        {
            _gameState = _gameState.PlayAgain(PlayAgain);
        }

        private bool PlayAgain() {
            return false;
        }

        public void End() {
            _gameState = _gameState.End();
        }

        public void Accept(IGameVisitor visitor) {
            visitor.Execute(_board, _players);
        }

   
    }
}