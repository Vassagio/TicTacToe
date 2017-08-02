using Xunit;

namespace Project.Mocks
{
    public class MockAction
    {
        private int _calledCount;

        public void Run() {
            _calledCount++;
        }

        public void VerifyActionCalled(int times = 1)
        {
            Assert.Equal(1, _calledCount);
        }

        public void VerifyActionNotCalled() {
            Assert.Equal(0, _calledCount);
        }
    }
}
