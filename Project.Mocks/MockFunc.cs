using Xunit;

namespace Project.Mocks {
    public class MockFunc<T> {
        private T _returnValue;
        private int _calledCount;

        public T Run() {
            _calledCount++;
            return _returnValue;
        } 

        public MockFunc<T> RunReturns(T value) {
            _returnValue = value;
            return this;
        }

        public void VerifyFunctionCalled(int times = 1)
        {
            Assert.Equal(times, _calledCount);
        }

        public void VerifyFunctionNotCalled() {
            Assert.Equal(0, _calledCount);
        }
    }
}