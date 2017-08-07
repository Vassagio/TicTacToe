namespace Test.Utilities.ValueType.Equality.Rules {
    internal class OverloadsEqualityOperator<T> : ImplementsMethod<T> {
        public OverloadsEqualityOperator() : base("op_Equality", "operator ==", typeof(T), typeof(T)) { }
    }
}