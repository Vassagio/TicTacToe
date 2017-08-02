using Moq;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Game.Builder
{
    public class MockPlayerType : IPlayerType
    {
        private readonly Mock<IPlayerType> _mock = new Mock<IPlayerType>();

        public PlayerType Human(string name, string symbol) => _mock.Object.Human(name, symbol);

        public PlayerType Computer(string name, string symbol) => _mock.Object.Computer(name, symbol);

        public IPlayer Player => _mock.Object.Player;

        public MockPlayerType PlayerReturns(IPlayer player) {
            _mock.Setup(m => m.Player).Returns(player);
            return this;
        }

        public void VerifyPlayerCalled(int times = 1) {
            _mock.Verify(m => m.Player, Times.Exactly(times));
        }
    }
}
