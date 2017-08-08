using TicTacToe.Core.Game.Service;
using TicTacToe.Core.Mocks.Player;
using TicTacToe.Core.Player;
using Xunit;

namespace TicTacToe.Core.Tests.Game.Service {
    public class GameServiceTest {
        [Fact]
        public void Initialize() {
            var service = BuildGameService();

            Assert.IsAssignableFrom<IGameService>(service);
        }

        [Fact]
        public void HasWinner_ReturnsTrue() {
            var service = BuildGameService();

            var hasWinner = service.HasWinner();

            Assert.False(hasWinner);
        }

        private static GameService BuildGameService(IPlayers players = null) {
            players = players ?? new MockPlayers();
            return new GameService(players);
        }
    }
}