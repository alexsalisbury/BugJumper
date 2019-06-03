namespace BugJumperCore.Tests
{
    using BugJumper;
    using System;
    using System.Reflection;
    using Xunit;

    public class GlobalKeyboardHook_Tests
    {
        private bool isEventFired = false;

        [Fact]
        public void Smoke()
        {
            using (GlobalKeyboardHook tbc = new GlobalKeyboardHook())
            {
                Assert.NotNull(tbc);
            }
        }

        [Fact]
        public void SmokeEvent()
        {
            IntPtr wParam = new IntPtr(32);
            IntPtr lParam = new IntPtr(0);
            this.isEventFired = false;
            using (GlobalKeyboardHook tbc = new GlobalKeyboardHook())
            {
                tbc.KeyboardPressed += testMethod;
                Assert.NotNull(tbc);
                tbc.LowLevelKeyboardProc(0, wParam, lParam);
            }
        }

        [Fact]
        public void SmokeEventHandle()
        {
            IntPtr wParam = new IntPtr(32);
            IntPtr lParam = new IntPtr(0);
            this.isEventFired = false;
            using (GlobalKeyboardHook tbc = new GlobalKeyboardHook())
            {
                tbc.KeyboardPressed += testMethodWithHandle;
                Assert.NotNull(tbc);
                tbc.LowLevelKeyboardProc(0, wParam, lParam);
            }
        }

        [Fact]
        public void MultiHook()
        {
            IntPtr wParam = new IntPtr(32);
            IntPtr lParam = new IntPtr(0);
            this.isEventFired = false;
            GlobalKeyboardHook ghk = new GlobalKeyboardHook();
            using (GlobalKeyboardHook tbc = new GlobalKeyboardHook())
            {
                tbc.KeyboardPressed += testMethod;
                Assert.NotNull(tbc);
            }
            Assert.NotNull(ghk);
            ghk.Dispose();
        }

        private void testMethod(object sender, GlobalKeyboardHookEventArgs e)
        {
            this.isEventFired = true;
        }

        private void testMethodWithHandle(object sender, GlobalKeyboardHookEventArgs e)
        {
            this.isEventFired = true;
            e.Handled = true;
        }
    }
}
