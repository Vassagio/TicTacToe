namespace Test.Utilities.ValueType.Equality.Rules {
    internal class OverridesGetHashCode<T> : ImplementsMethod<T> {
        public OverridesGetHashCode() : base("GetHashCode") { }
    }
}