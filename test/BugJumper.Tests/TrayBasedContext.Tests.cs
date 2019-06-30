namespace BugJumperCore.Tests
{
    using BugJumper;
    using BugJumper.Config;
    using System.Reflection;
    using Xunit;

    public class TrayBasedContext_Tests
    {
        [Fact]
        public void Smoke()
        {
            GlobalKeyboardHook ghk = new GlobalKeyboardHook();
            TrayBasedContext tbc = new TrayBasedContext(null, new KeyPressState(), new JsonConfigProvider(string.Empty));

            Assert.NotNull(tbc);
        }

        [Fact]
        public void KeyEvent()
        {
            TrayBasedContext tbc = new TrayBasedContext(null, new KeyPressState(), new JsonConfigProvider(string.Empty));
            var llie = new LowLevelKeyboardInputEvent();
            var g = new GlobalKeyboardHookEventArgs(llie, KeyboardState.KeyUp);


            tbc.HandleKey(null, g);

        }
    }
}
