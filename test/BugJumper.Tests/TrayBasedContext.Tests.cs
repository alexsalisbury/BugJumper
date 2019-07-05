namespace BugJumperCore.Tests
{
    using BugJumper;
    using BugJumper.Config;
    using System.Reflection;
    using Xunit;

    public class TrayBasedContext_Tests
    {
        const string localConfig = @".\BugJumperConfig.json";

        [Fact]
        public void Smoke()
        {
            GlobalKeyboardHook ghk = new GlobalKeyboardHook();
            TrayBasedContext tbc = new TrayBasedContext(null, new KeyPressState(), new JsonConfigProvider(localConfig));

            Assert.NotNull(tbc);
        }

        [Fact]
        public void KeyEvent()
        {
            TrayBasedContext tbc = new TrayBasedContext(null, new KeyPressState(), new JsonConfigProvider(localConfig));
            var llie = new LowLevelKeyboardInputEvent();
            var g = new GlobalKeyboardHookEventArgs(llie, KeyboardState.KeyUp);


            tbc.HandleKey(null, g);

        }
    }
}
