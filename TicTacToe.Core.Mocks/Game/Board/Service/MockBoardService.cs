using System.Collections.Generic;
using Moq;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Board.Tile;

namespace TicTacToe.Core.Mocks.Game.Board.Service {
    public class MockBoardService : IBoardService {
        private readonly Mock<IBoardService> _mock = new Mock<IBoardService>();

        public IEnumerable<ITile> GenerateTilesWithCoordinates(int size) => _mock.Object.GenerateTilesWithCoordinates(size);

        public MockBoardService GenerateTilesWithCoordinatesReturns(IEnumerable<ITile> tiles) {
            _mock.Setup(m => m.GenerateTilesWithCoordinates(It.IsAny<int>())).Returns(tiles);
            return this;
        }

        public void VerifyGenerateTilesWithCoordinates(int size, int times = 1) {
            _mock.Verify(m => m.GenerateTilesWithCoordinates(size), Times.Exactly(times));
        }
    }
}