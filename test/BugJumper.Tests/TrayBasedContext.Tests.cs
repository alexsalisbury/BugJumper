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

        [Fact]
        public void KeyEvent()
        {
            TrayBasedContext tbc = new TrayBasedContext(null);
            var llie = new LowLevelKeyboardInputEvent();
            var g = new GlobalKeyboardHookEventArgs(llie, KeyboardState.KeyUp);


            tbc.HandleKey(null, g);

        }
    }
}
