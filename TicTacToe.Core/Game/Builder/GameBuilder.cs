using System.Collections.Generic;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Game.Builder {
    public class GameBuilder : IGameBuilder, IGameBuilderSetFirstPlayer, IGameBuilderSetSecondPlayer, IGameBuilderSetStartingPlayer {
        public static IGameBuilderSetFirstPlayer WithBoardSize(int size) => new GameBuilder(size);
        private readonly int _size;
        private readonly Dictionary<IStartingPlayer, IPlayer> _startingPlayerMapper = new Dictionary<IStartingPlayer, IPlayer>();
        private IPlayers _players = new Players();

        private GameBuilder(int size) => _size = size;

        public TicTacToeGame Create() {
            var board = TicTacToeBoard.Initialize(_size);
            return new TicTacToeGame(board, _players, new GameService());
        }

        public IGameBuilderSetSecondPlayer FirstPlayerSet(IPlayerTypeCreate playerType) {
            var player = playerType.Create();
            _players = _players.Add(player);
            _startingPlayerMapper.Add(StartingPlayer.As().FirstPlayer(), player);
            return this;
        }

        public IGameBuilderSetStartingPlayer SecondPlayerSet(IPlayerTypeCreate playerType) {
            var player = playerType.Create();
            _players = _players.Add(player);
            _startingPlayerMapper.Add(StartingPlayer.As().SecondPlayer(), player);
            return this;
        }

        public IGameBuilder Set(IStartingPlayer startingPlayer) {
            _players = _players.SetCurrentPlayer(_startingPlayerMapper[startingPlayer]);
            return this;
        }
    }
}