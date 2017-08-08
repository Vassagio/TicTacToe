using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Game.States;
using TicTacToe.Core.Game.Visitor;

namespace TicTacToe.Core.Game {
    public sealed class TicTacToeGame {
        private IBoard _board;
        private readonly IGameService _gameService;
        private IGameState _gameState;

        internal TicTacToeGame(IBoard board, IGameService gameService, IGameState gameState) {
            _board = board;
            _gameService = gameService;
            _gameState = gameState;
        }

        public bool StillGoing => !(_gameState is EndGameState);

        public void Start() {
            _gameState = _gameState.Start();
        }

        public void Play() {
            _gameState = _gameState.Play(_gameService.MakeMove);
        }        

        public void CheckForWin() {
            _gameState = _gameState.CheckForWin(_gameService.HasWinner);
        }
        
        public void SwitchPlayer() {
            _gameState = _gameState.SwitchPlayer(_gameService.SwitchPlayer);           
        }        

        public void Over() {
            _gameState = _gameState.Over();
        }

        public void PlayAgain()
        {
            _gameState = _gameState.PlayAgain(_gameService.PlayAgain);
        }

        public void End() {
            _gameState = _gameState.End();
        }

        public void Accept(IGameVisitor visitor) {
            visitor.Execute(_board);
        }

   
    }
}