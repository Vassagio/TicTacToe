using System.Collections.Generic;
using Moq;
using TicTacToe.Core.Game.Board.Service;
using TicTacToe.Core.Game.Board.Tile;

namespace TicTacToe.Core.Mocks.Game.Board.Service {
    public class MockBoardService : IBoardService {
        private readonly Mock<IBoardService> _mock = new Mock<IBoardService>();

        public IEnumerable<EmptyTile> GenerateEmptyTilesWithAvailableCoordinates(int size) => _mock.Object.GenerateEmptyTilesWithAvailableCoordinates(size);
    }
}