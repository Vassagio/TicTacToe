using Moq;
using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Mocks.Game.Board.Tile.Coordinate {
    public class MockCoordinate : ICoordinate {
        private readonly Mock<ICoordinate> _mock = new Mock<ICoordinate>();

        public int X => _mock.Object.X;
        public int Y => _mock.Object.Y;
    }
}