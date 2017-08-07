using System;
using Moq;
using TicTacToe.Core.Game.States;

namespace TicTacToe.Core.Mocks.Game.States
{
    public class MockGameState: IGameState
    {
        private readonly Mock<IGameState> _mock = new Mock<IGameState>();
        
        public IGameState Start() => _mock.Object.Start();
        public IGameState Play(Action makeMove) => _mock.Object.Play(makeMove);
        public IGameState CheckForWin(Func<bool> hasWinner) => _mock.Object.CheckForWin(hasWinner);
        public IGameState SwitchPlayer(Action getNextPlayer) => _mock.Object.SwitchPlayer(getNextPlayer);
        public IGameState Over() => _mock.Object.Over();
        public IGameState PlayAgain(Func<bool> playAgain) => _mock.Object.PlayAgain(playAgain);
        public IGameState End() => _mock.Object.End();
        public IGameState DeepClone() => _mock.Object.DeepClone();

        public void VerifyStartCalled(int times = 1) {
            _mock.Verify(m => m.Start(), Times.Exactly(times));
        }

        public void VerifyOverCalled(int times = 1) {
            _mock.Verify(m => m.Over(), Times.Exactly(times));
        }

        public void VerifyEndCalled(int times = 1) {
            _mock.Verify(m => m.End(), Times.Exactly(times));
        }

        public void VerifyPlayCalled(int times = 1) {
            _mock.Verify(m => m.Play(It.IsAny<Action>()), Times.Exactly(times));
        }

        public void VerifyCheckForWinCalled(int times = 1) {
            _mock.Verify(m => m.CheckForWin(It.IsAny<Func<bool>>()), Times.Exactly(times));
        }

        public void VerifySwitchPlayerCalled(int times = 1) {
            _mock.Verify(m => m.SwitchPlayer(It.IsAny<Action>()), Times.Exactly(times));
        }

        public void VerifyPlayAgainCalled(int times = 1)
        {
            _mock.Verify(m => m.PlayAgain(It.IsAny<Func<bool>>()), Times.Exactly(times));
        }

    }
}
