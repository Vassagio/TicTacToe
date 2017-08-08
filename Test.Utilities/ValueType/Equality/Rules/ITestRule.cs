using System.Collections.Generic;

namespace Test.Utilities.ValueType.Equality.Rules {
    internal interface ITestRule {
        IEnumerable<string> GetErrorMessages();
    }
}