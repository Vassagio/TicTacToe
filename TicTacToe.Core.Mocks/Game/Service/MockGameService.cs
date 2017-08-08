using Moq;
using TicTacToe.Core.Game.Service;

namespace TicTacToe.Core.Mocks.Game.Service
{
    public class MockGameService : IGameService
    {

        private readonly Mock<IGameService> _mock = new Mock<IGameService>();

        public bool HasWinner() => _mock.Object.HasWinner();
        public void MakeMove() => _mock.Object.MakeMove();
        public void SwitchPlayer() => _mock.Object.SwitchPlayer();
        public bool PlayAgain() => _mock.Object.PlayAgain();
    }
}
