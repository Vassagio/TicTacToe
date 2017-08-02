using Moq;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Player
{
    public class MockPlayers: IPlayers
    {
        private readonly Mock<IPlayers> _mock = new Mock<IPlayers>();

        public IPlayer Current => _mock.Object.Current;
        public IPlayers Next() => _mock.Object.Next();
        public IPlayers Add(IPlayer player) => _mock.Object.Add(player);
        public IPlayers SetCurrentPlayer(IPlayer currentPlayer) => _mock.Object.SetCurrentPlayer(currentPlayer);

        public MockPlayers AddReturns(IPlayers players) {
            _mock.Setup(m => m.Add(It.IsAny<IPlayer>())).Returns(players);
            return this;
        }

        public MockPlayers AddReturnsItself()
        {
            _mock.Setup(m => m.Add(It.IsAny<IPlayer>())).Returns(this);
            return this;
        }

        public void VerifyAddCalled(IPlayer player, int times = 1) {
            _mock.Verify(m => m.Add(player), Times.Exactly(times));
        }

        public MockPlayers CurrentReturns(IPlayer player) {
            _mock.Setup(m => m.Current).Returns(player);
            return this;
        }

        public MockPlayers SetCurrentPlayerReturns(IPlayers players) {
            _mock.Setup(m => m.SetCurrentPlayer(It.IsAny<IPlayer>())).Returns(players);
            return this;
        }

        public void VerifySetCurrentPlayerCalled(IPlayer player, int times = 1) {
            _mock.Verify(m => m.SetCurrentPlayer(player), Times.Exactly(times));
        }
    }
}
