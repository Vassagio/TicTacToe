using System.Collections.Generic;
using Moq;
using TicTacToe.Core.Game.Board;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Game.Board
{
    public class MockBoard : IBoard
    {
        private readonly Mock<IBoard> _mock = new Mock<IBoard>();

        public int Count => _mock.Object.Count;
        public int Size => _mock.Object.Size;

        public IEnumerator<ITile> GetEnumerator() => _mock.Object.GetEnumerator();
        public ITile GetTileBy(ICoordinate coordinate) => _mock.Object.GetTileBy(coordinate);
        public ITile GetTileBy(int position) => _mock.Object.GetTileBy(position);
        public ITile GetTileBy(int x, int y) => _mock.Object.GetTileBy(x, y);
        public TicTacToeBoard ReserveTileBy(ICoordinate coordinate, IPlayer currentPlayer) => _mock.Object.ReserveTileBy(coordinate, currentPlayer);
        public TicTacToeBoard ReserveTileBy(int x, int y, IPlayer currentPlayer) => _mock.Object.ReserveTileBy(x, y, currentPlayer);
        public TicTacToeBoard ReserveTileBy(int position, IPlayer currentPlayer) => _mock.Object.ReserveTileBy(position, currentPlayer);
    }
}
