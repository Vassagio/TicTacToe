namespace Project.Utilities
{
    public interface IDeepCloneable<out T> where T: class
    {
        T DeepClone();
    }

    public interface IShallowCloneable<out T> where T : class
    {
        T ShallowClone();
    }
}
