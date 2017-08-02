using System;
using System.Linq.Expressions;
using Project.Utilities;

namespace Test.Utilities.StateHelper {
    public interface IStateWhen<T> where T : class, IDeepCloneable<T> {
        IStateTransition<T> When(Expression<Func<T>> predicate);        
    }
}