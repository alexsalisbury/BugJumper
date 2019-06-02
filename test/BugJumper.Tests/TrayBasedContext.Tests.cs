namespace BugJumperCore.Tests
{
    using BugJumper;
    using System.Reflection;
    using Xunit;

    public class TrayBasedContext_Tests
    {
        [Fact]
        public void Smoke()
        {
            TrayBasedContext tbc = new TrayBasedContext(null);

            Assert.NotNull(tbc);
        }
    }
}
