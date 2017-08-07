using Moq;
using TicTacToe.Core.Game.Board.Tile;
using TicTacToe.Core.Game.Board.Tile.Coordinate;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Game.Board.Tile
{
    public class MockTile : ITile
    {
        private readonly Mock<ITile> _mock = new Mock<ITile>();

        public IPlayer Player => _mock.Object.Player;
        public int Position => _mock.Object.Position;
        public ICoordinate Coordinate => _mock.Object.Coordinate;
        public ITile SetPlayer(IPlayer player) => _mock.Object.SetPlayer(player);

        public MockTile CoordinateReturns(ICoordinate coordinate) {
            _mock.Setup(m => m.Coordinate).Returns(coordinate);
            return this;
        }

        public MockTile PositionReturns(int position) {
            _mock.Setup(m => m.Position).Returns(position);
            return this;
        }

        public MockTile SetPlayerReturns(ITile tile)
        {
            _mock.Setup(m => m.SetPlayer(It.IsAny<IPlayer>())).Returns(tile);
            return this;
        }

        public MockTile SetPlayerReturnsItself() {
            _mock.Setup(m => m.SetPlayer(It.IsAny<IPlayer>())).Returns(this);
            return this;
        }

        public MockTile PlayerReturns(IPlayer player)
        {
            _mock.Setup(m => m.Player).Returns(player);
            return this;
        }

        public void VerifyCoordinateCalled(int times = 1) {
            _mock.Verify(m => m.Coordinate, Times.Exactly(times));
        }

        public void VerifyPositionCalled(int times = 1)
        {
            _mock.Verify(m => m.Position, Times.Exactly(times));
        }

        public void VerifySetPlayerCalled(IPlayer player, int times = 1) {
            _mock.Verify(m => m.SetPlayer(player), Times.Exactly(times));
        }

        public void VerifyPlayerCalled(int times = 1) {
            _mock.Verify(m => m.Player, Times.Exactly(times));
        }
    }
}
