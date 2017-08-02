using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Mocks.Game.Board.Service;
using TicTacToe.Core.Mocks.Game.Builder;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Builder
{
    public class GameBuilderTest
    {
        [Fact]
        public void Build_ReturnsAGame()
        {
            var builder = BuildGameBuilder();

            var game = builder.Build();

            Assert.NotNull(game);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        public void Build_SetSize_ReturnsGameWithBoardOfThatSize(int size)
        {
            var boardInspector = new InspectorGameVisitor();
            var builder = BuildGameBuilder(size: size);

            var game = builder.Build();

            game.Accept(boardInspector);
            Assert.Equal(size, boardInspector.Board.Size);
        }

        //BoardServiceTest

        [Fact]
        public void Build_FirstPlayerType_VerifyFirstPlayerAdded()
        {
            var player = new MockPlayer();
            var startingPlayerMapper = new MockStartingPlayerMapper().AddReturnsItself();
            var players = new MockPlayers().AddReturnsItself();
            var firstPlayerType = new MockPlayerType().PlayerReturns(player);
            var builder = BuildGameBuilder(startingPlayerMapper, players, firstPlayerType: firstPlayerType);

            builder.Build();

            firstPlayerType.VerifyPlayerCalled();
            players.VerifyAddCalled(player);
            startingPlayerMapper.VerifyAddCalled(StartingPlayer.As().FirstPlayer(), player);
        }

        [Fact]
        public void Build_SecondPlayerType_VerifySecondPlayerAdded()
        {
            var player = new MockPlayer();
            var startingPlayerMapper = new MockStartingPlayerMapper().AddReturnsItself();
            var players = new MockPlayers().AddReturnsItself();
            var secondPlayerType = new MockPlayerType().PlayerReturns(player);
            var builder = BuildGameBuilder(startingPlayerMapper, players, secondPlayerType: secondPlayerType);

            builder.Build();

            secondPlayerType.VerifyPlayerCalled();
            players.VerifyAddCalled(player);
            startingPlayerMapper.VerifyAddCalled(StartingPlayer.As().SecondPlayer(), player);
        }

        [Fact]
        public void Build_SetStartingPlayer()
        {
            var player1 = new MockPlayer();
            var player2 = new MockPlayer();
            var expectedPlayers = new MockPlayers().CurrentReturns(player1);
            var startingPlayerMapper = new MockStartingPlayerMapper().AddReturnsItself().KeyReturns(player1);            
            var players = new MockPlayers().AddReturnsItself().SetCurrentPlayerReturns(expectedPlayers);
            var firstPlayerType = new MockPlayerType().PlayerReturns(player1);
            var secondPlayerType = new MockPlayerType().PlayerReturns(player2);
            var startingPlayer = new MockStartingPlayer();
            var builder = BuildGameBuilder(startingPlayerMapper, players, firstPlayerType: firstPlayerType, secondPlayerType: secondPlayerType, startingPlayer: startingPlayer);

            builder.Build();

            players.VerifySetCurrentPlayerCalled(player1);
            startingPlayerMapper.VerifyKeyCalled(startingPlayer);
        }

        private static IGameBuilder BuildGameBuilder(IStartingPlayerMapper startingPlayerMapper = null, 
                                                     IPlayers players = null, 
                                                     IBoardService boardService = null,
                                                     int? size = null, 
                                                     IPlayerType firstPlayerType = null, 
                                                     IPlayerType secondPlayerType = null, 
                                                     IStartingPlayer startingPlayer = null) {
            startingPlayerMapper = startingPlayerMapper  ?? new MockStartingPlayerMapper().AddReturnsItself();
            players = players  ?? new MockPlayers().AddReturnsItself();
            boardService = boardService ?? new MockBoardService();            
            size = size ?? 3;
            firstPlayerType = firstPlayerType ?? new MockPlayerType();
            secondPlayerType = secondPlayerType ?? new MockPlayerType();
            startingPlayer = startingPlayer ?? new MockStartingPlayer();
            return GameBuilder
                .Initialize(startingPlayerMapper, players, boardService)
                .WithBoardSize(size.Value)
                .FirstPlayerSet(firstPlayerType)
                .SecondPlayerSet(secondPlayerType)
                .Set(startingPlayer);
        }
    }
}
