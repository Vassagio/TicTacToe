using Test.Utilities.ValueType.Equality;

namespace Test.Utilities.ValueType {
    public static class EqualityTests {
        public static EqualityTester<T> For<T>(T obj) => new EqualityTester<T>(obj);
    }
}