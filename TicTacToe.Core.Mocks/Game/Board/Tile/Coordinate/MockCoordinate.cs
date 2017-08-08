using Moq;
using TicTacToe.Core.Game.Board.Tile.Coordinate;

namespace TicTacToe.Core.Mocks.Game.Board.Tile.Coordinate {
    public class MockCoordinate : ICoordinate {
        private readonly Mock<ICoordinate> _mock = new Mock<ICoordinate>();

        public int X => _mock.Object.X;
        public int Y => _mock.Object.Y;

        public MockCoordinate XReturns(int x) {
            _mock.Setup(m => m.X).Returns(x);
            return this;
        }

        public MockCoordinate YReturns(int y) {
            _mock.Setup(m => m.Y).Returns(y);
            return this;
        }

        public void VerifyXCalled(int times = 1) {
            _mock.Verify(m => m.X, Times.Exactly(times));
        }

        public void VerifyYCalled(int times = 1)
        {
            _mock.Verify(m => m.Y, Times.Exactly(times));
        }
    }
}