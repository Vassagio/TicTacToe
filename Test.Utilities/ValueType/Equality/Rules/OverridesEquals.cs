namespace Test.Utilities.ValueType.Equality.Rules {
    internal class OverridesEquals<T> : ImplementsMethod<T> {
        public OverridesEquals() : base("Equals", typeof(object)) { }
    }
}