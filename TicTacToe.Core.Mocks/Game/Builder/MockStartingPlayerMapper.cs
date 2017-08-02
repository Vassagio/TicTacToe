using Moq;
using TicTacToe.Core.Game.Builder;
using TicTacToe.Core.Player;

namespace TicTacToe.Core.Mocks.Game.Builder {
    public class MockStartingPlayerMapper : IStartingPlayerMapper {
        private readonly Mock<IStartingPlayerMapper> _mock = new Mock<IStartingPlayerMapper>();

        public IPlayer this[IStartingPlayer key] => _mock.Object[key]; 
        public IStartingPlayerMapper Add(IStartingPlayer startingPlayer, IPlayer player) => _mock.Object.Add(startingPlayer, player);

        public MockStartingPlayerMapper AddReturns(IStartingPlayerMapper startingPlayerMapper) {
            _mock.Setup(m => m.Add(It.IsAny<IStartingPlayer>(), It.IsAny<IPlayer>())).Returns(startingPlayerMapper);
            return this;
        }

        public MockStartingPlayerMapper AddReturnsItself()
        {
            _mock.Setup(m => m.Add(It.IsAny<IStartingPlayer>(), It.IsAny<IPlayer>())).Returns(this);
            return this;
        }

        public MockStartingPlayerMapper KeyReturns(IPlayer player) {
            _mock.Setup(m => m[It.IsAny<IStartingPlayer>()]).Returns(player);
            return this;
        }

        public void VerifyAddCalled(IStartingPlayer startingPlayer, IPlayer player, int times = 1) {
            _mock.Verify(m => m.Add(startingPlayer, player), Times.Exactly(times));
        }

        public void VerifyKeyCalled(IStartingPlayer startingPlayer, int times = 1) {
            _mock.Verify(m => m[startingPlayer], Times.Exactly(times));
        }
    }
}