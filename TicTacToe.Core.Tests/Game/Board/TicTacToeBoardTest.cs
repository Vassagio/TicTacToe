using System.Collections.Generic;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Mocks.Game.Board.Service;
using TicTacToe.Core.Mocks.Game.Board.Tile;
using TicTacToe.Core.Mocks.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Mocks.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Board
{
    public class TicTacToeBoardTest
    {
        [Fact]
        public void Initialize() {
            var board = BuildBoard();

            Assert.IsAssignableFrom<IBoard>(board);
        }

        [Fact]
        public void Initialize_SetsSize()
        {
            const int SIZE = 17;
            var board = BuildBoard(SIZE);

            Assert.Equal(SIZE, board.Size);
        }

        [Fact]
        public void Initialize_VerifyGenerateTilesWithCoordinatesCalled() {
            const int SIZE = 29;
            var tiles = new List<ITile> {
                new MockTile()
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(SIZE, boardService);

            Assert.Equal(board, tiles);
            boardService.VerifyGenerateTilesWithCoordinates(SIZE);
        }

        [Fact]        
        public void Count_NumberOfTiles()
        {
            var tiles = new List<ITile> {
                new MockTile(),
                new MockTile(),
                new MockTile()
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var count = board.Count;

            Assert.Equal(3, count);
        }

        [Fact]
        public void GetTile_ByCoordinate_ReturnsTile()
        {            
            var coordinate = new MockCoordinate();
            var tile = new MockTile().CoordinateReturns(coordinate);
            var tiles = new List<ITile> {
                new MockTile().CoordinateReturns(new MockCoordinate()),
                tile,
                new MockTile().CoordinateReturns(new MockCoordinate())
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var actual = board.GetTileBy(coordinate);

            Assert.Equal(tile, actual);
            tile.VerifyCoordinateCalled();
        }

        [Fact]
        public void GetTile_ByCoordinate_WithUnknownCoordinate_ReturnsOutOfBoundsTile()
        {                                    
            var board = BuildBoard();

            var actual = board.GetTileBy(new MockCoordinate());

            Assert.IsType<OutOfBoundsTile>(actual);            
        }

        [Fact]
        public void GetTile_ByCoordinate_WithNull_ReturnsOutOfBoundsTile()
        {
            var board = BuildBoard();

            var actual = board.GetTileBy(null);

            Assert.IsType<OutOfBoundsTile>(actual);
        }

        [Fact]
        public void GetTile_ByXY_ReturnsTile()
        {
            const int X = 3;
            const int Y = 2;
            var coordinate = new MockCoordinate().XReturns(X).YReturns(Y);
            var tile = new MockTile().CoordinateReturns(coordinate);
            var tiles = new List<ITile> {
                new MockTile().CoordinateReturns(new MockCoordinate()),
                new MockTile().CoordinateReturns(new MockCoordinate()),
                tile
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var actual = board.GetTileBy(X, Y);

            Assert.Equal(tile, actual);
            tile.VerifyCoordinateCalled(2);
            coordinate.VerifyXCalled();
            coordinate.VerifyYCalled();
        }

        [Fact]
        public void GetTile_ByXY_WhenNotExist_ReturnsOutOfBoundsTile()
        {
            const int X = 4;
            const int Y = 7;
            var board = BuildBoard();

            var actual = board.GetTileBy(X, Y);

            Assert.IsType<OutOfBoundsTile>(actual);
        }

        [Fact]
        public void GetTile_ByPosition_ReturnsTile()
        {
            const int POSITION = 7;
            var tile = new MockTile().PositionReturns(POSITION);
            var tiles = new List<ITile> {
                tile,
                new MockTile().CoordinateReturns(new MockCoordinate()),
                new MockTile().CoordinateReturns(new MockCoordinate())
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var actual = board.GetTileBy(POSITION);

            Assert.Equal(tile, actual);
            tile.VerifyPositionCalled();
        }

        [Fact]
        public void GetTile_ByPosition_WhenNotExist_ReturnsOutOfBoundsTile()
        {
            const int POSITION = 6;
            var board = BuildBoard();

            var actual = board.GetTileBy(POSITION);

            Assert.IsType<OutOfBoundsTile>(actual);
        }

        [Fact]
        public void SetTile_ByCoordinate_ReturnsNewBoardWithUpdatedTile()
        {
            var player = new MockPlayer();
            var coordinate = new MockCoordinate();
            var newTile = new MockTile().PlayerReturns(player);
            var tile = new MockTile().CoordinateReturns(coordinate).SetPlayerReturns(newTile);
            var tiles = new List<ITile> {
                new MockTile().CoordinateReturns(new MockCoordinate()),
                new MockTile().CoordinateReturns(new MockCoordinate()),
                tile
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var newBoard = board.ReserveTileBy(coordinate, player);

            Assert.NotEqual(board, newBoard);
            tile.VerifySetPlayerCalled(player);
        }

        [Fact]
        public void SetTile_ByCoordinate_WithUnknownCoordinate_ReturnsOriginalBoard()
        {
            var board = BuildBoard();

            var newBoard = board.ReserveTileBy(new MockCoordinate(), new MockPlayer());

            Assert.Equal(board, newBoard);
        }

        [Fact]
        public void SetTile_ByCoordinate_WithNull_ReturnsOriginalBoard()
        {
            var board = BuildBoard();

            var newBoard = board.ReserveTileBy(null, new MockPlayer());

            Assert.Equal(board, newBoard);
        }

        [Fact]
        public void GetTile_ByXY_ReturnsNewBoardWithUpdatedTile()
        {
            const int X = 3;
            const int Y = 2;
            var player = new MockPlayer();
            var coordinate = new MockCoordinate().XReturns(X).YReturns(Y);
            var newTile = new MockTile().PlayerReturns(player);
            var tile = new MockTile().CoordinateReturns(coordinate).SetPlayerReturns(newTile);
            var tiles = new List<ITile> {
                new MockTile().CoordinateReturns(new MockCoordinate()),
                new MockTile().CoordinateReturns(new MockCoordinate()),
                tile
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var newBoard = board.ReserveTileBy(X, Y, player);

            Assert.NotEqual(board, newBoard);
            tile.VerifySetPlayerCalled(player);
        }

        [Fact]
        public void GetTile_ByXY_WhenNotExist_ReturnsOriginalBoard()
        {
            const int X = 4;
            const int Y = 7;
            var board = BuildBoard();

            var newBoard = board.ReserveTileBy(X, Y, new MockPlayer());

            Assert.Equal(board, newBoard);
        }

        [Fact]
        public void GetTile_ByPosition_ReturnsNewBoardWithUpdatedTile()
        {
            const int POSITION = 7;
            var player = new MockPlayer();            
            var newTile = new MockTile().PositionReturns(POSITION).PlayerReturns(player);
            var tile = new MockTile().PositionReturns(POSITION).SetPlayerReturns(newTile);
            var tiles = new List<ITile> {
                new MockTile().PositionReturns(5),
                new MockTile().PositionReturns(2),
                tile
            };
            var boardService = new MockBoardService().GenerateTilesWithCoordinatesReturns(tiles);
            var board = BuildBoard(boardService: boardService);

            var newBoard = board.ReserveTileBy(POSITION, player);

            Assert.NotEqual(board, newBoard);
            tile.VerifySetPlayerCalled(player);
        }

        [Fact]
        public void GetTile_ByPosition_WhenNotExist_ReturnsOriginalBoard()
        {
            const int POSITION = 6;
            var board = BuildBoard();

            var newBoard = board.ReserveTileBy(POSITION, new MockPlayer());

            Assert.Equal(board, newBoard);
        }        

        private static TicTacToeBoard BuildBoard(int? size = null, IBoardService boardService = null) {
            size = size ?? 3;
            boardService = boardService ?? new MockBoardService().GenerateTilesWithCoordinatesReturns(new List<ITile>()); ;
            return TicTacToeBoard.Initialize(size.Value, boardService);
        }
    }
}
