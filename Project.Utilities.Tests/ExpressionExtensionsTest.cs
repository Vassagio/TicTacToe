using System;
using System.Linq.Expressions;
using Xunit;

namespace Project.Utilities.Tests {
    public class ExpressionExtensionsTest {
        [Fact]
        public void GetName() {
            Expression<Func<bool>> testExpression = () => TestExpression();

            var name = testExpression.GetName();

            Assert.Equal("TestExpression", name);
        }

        private bool TestExpression() => true;
    }
}