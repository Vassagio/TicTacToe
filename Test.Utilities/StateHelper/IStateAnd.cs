using Project.Utilities;

namespace Test.Utilities.StateHelper {
    public interface IStateAnd<T> where T : class, IDeepCloneable<T> {
        IStateWhen<T> And();
        void Assert();        
    }
}