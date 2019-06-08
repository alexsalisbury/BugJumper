namespace BugJumper
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public struct KeyPressState
    {
        public bool IsWin { get; set; }
        public bool IsCtrl { get; set; }
        public bool IsAlt { get; set; }
        public bool IsShift { get; set; }
        public Keys? Key { get; set; }

        public static KeyPressState Create(Dictionary<Keys, bool> controlState, Keys? key)
        {
            return new KeyPressState()
            {
                IsWin = controlState[Keys.LWin] || controlState[Keys.RWin],
                IsCtrl = controlState[Keys.LControlKey] || controlState[Keys.RControlKey],
                IsAlt = controlState[Keys.LMenu] || controlState[Keys.RMenu],
                IsShift = controlState[Keys.LShiftKey] || controlState[Keys.RShiftKey],
                Key = key
            };
        }

        public override bool Equals(object obj)
        {
            if (!(obj is KeyPressState))
            {
                return false;
            }

            KeyPressState mys = (KeyPressState)obj;

            // This order is an attempt to try to fail as fast as possible. 
            if (this.Key != mys.Key)
            {
                return false;
            }
            if (this.IsCtrl != mys.IsCtrl)
            {
                return false;
            }
            if (this.IsShift != mys.IsShift)
            {
                return false;
            }
            if (this.IsAlt != mys.IsAlt)
            {
                return false;
            }

            return IsWin == mys.IsWin;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IsWin, IsCtrl, IsAlt, IsShift, Key);
        }
    }
}
