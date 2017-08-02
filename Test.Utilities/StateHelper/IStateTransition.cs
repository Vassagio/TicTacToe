using System;
using Project.Utilities;

namespace Test.Utilities.StateHelper {
    public interface IStateTransition<T> where T : class, IDeepCloneable<T> {
        IStateAnd<T> TransitionTo<TConcreteType>(Func<TConcreteType> create) where TConcreteType : class, T;
        void Invoke();
    }
}