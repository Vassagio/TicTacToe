using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public class GameBuilder : IGameBuilder, IGameBuilderSetSize, IGameBuilderSetFirstPlayer, IGameBuilderSetSecondPlayer, IGameBuilderSetStartingPlayer {
        public static IGameBuilderSetSize Initialize(IStartingPlayerMapper startingPlayerMapper, IPlayers players, IBoardService boardService) => new GameBuilder(startingPlayerMapper, players, boardService);        
        private int _size;
        private IStartingPlayerMapper _startingPlayerMapper;
        private IPlayers _players;
        private readonly IBoardService _boardService;

        private GameBuilder(IStartingPlayerMapper startingPlayerMapper, IPlayers players, IBoardService boardService) {
            _startingPlayerMapper = startingPlayerMapper;
            _players = players;
            _boardService = boardService;
        } 

        public TicTacToeGame Build() {
            var board = TicTacToeBoard.Initialize(_size, _boardService);
            return new TicTacToeGame(board, _players, new GameService());
        }

        public IGameBuilderSetFirstPlayer WithBoardSize(int size) {
            _size = size;
            return this;
        }

        public IGameBuilderSetSecondPlayer FirstPlayerSet(IPlayerType playerType) {
            var player = playerType.Player;
            _players = _players.Add(player);
            _startingPlayerMapper = _startingPlayerMapper.Add(StartingPlayer.As().FirstPlayer(), player);
            return this;
        }

        public IGameBuilderSetStartingPlayer SecondPlayerSet(IPlayerType playerType) {
            var player = playerType.Player;
            _players = _players.Add(player);
            _startingPlayerMapper = _startingPlayerMapper.Add(StartingPlayer.As().SecondPlayer(), player);
            return this;
        }

        public IGameBuilder Set(IStartingPlayer startingPlayer) {
            _players = _players.SetCurrentPlayer(_startingPlayerMapper[startingPlayer]);
            return this;
        }
    }
}