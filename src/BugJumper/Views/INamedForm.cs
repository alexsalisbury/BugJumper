namespace BugJumper.Views
{
    public interface INamedForm
    {
#if NETCOREAPP3_0
        static string CanonicalNameCore { get; }
#else
        string CanonicalName { get; }
#endif
    }
}
