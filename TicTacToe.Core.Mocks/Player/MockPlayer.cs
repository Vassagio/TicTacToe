using Moq;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Player {
    public class MockPlayer : IPlayer {
        public string Name => _mock.Object.Name;
        public string Symbol => _mock.Object.Symbol;
        private readonly Mock<IPlayer> _mock = new Mock<IPlayer>();
        public ICoordinate GetNextMove() => _mock.Object.GetNextMove();
    }
}