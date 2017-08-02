using System;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Player;

namespace TicTacToe.UI {
    public class Application : IApplication
    {
        private readonly IStartingPlayerMapper _startingPlayerMapper;
        private readonly IPlayers _players;
        private readonly IBoardService _boardService;

        public Application(IStartingPlayerMapper startingPlayerMapper, IPlayers players, IBoardService boardService) {
            _startingPlayerMapper = startingPlayerMapper;
            _players = players;
            _boardService = boardService;
        }

        public void Run() {            
            var game = GameBuilder
                .Initialize(_startingPlayerMapper, _players, _boardService)
                .WithBoardSize(3)
                .FirstPlayerSet(PlayerType.As().Human("Player", "X"))
                .SecondPlayerSet(PlayerType.As().Computer("Computer", "O"))
                .Set(StartingPlayer.As().FirstPlayer())
                .Build();

            do {
                game.Accept(new PrintBoardVisitor());
                game.Start();
                game.Play();
                game.CheckForWin();
                game.SwitchPlayer();
                game.Over();
                game.NewGame();
                game.End();
            } while (game.StillGoing);
        }
    }
}