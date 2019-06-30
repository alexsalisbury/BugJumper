namespace BugJumper.Models
{
    using System.Dynamic;

    /// <summary>
    /// Original source:
    /// https://github.com/alexsalisbury/Home/tree/master/src/Home.Configuration
    /// </summary>
    /// <see cref="https://github.com/mizrael/DynamicConfig/blob/10a569707b7bcf89dd8596c84b1b5f7d33dd573c/DynamicConfig/Models/NullExceptionPreventer.cs"/>
    public class NullExceptionPreventer : DynamicObject
    {
        // all member access to a NullExceptionPreventer will return a new NullExceptionPreventer
        // this allows for infinite nesting levels: var s = Obj1.foo.bar.bla.blubb; is perfectly valid
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new NullExceptionPreventer();
            return true;
        }

        public static implicit operator bool(NullExceptionPreventer nep)
        {
            return false;
        }

        public static implicit operator bool?(NullExceptionPreventer nep)
        {
            return null;
        }

        public static implicit operator bool[](NullExceptionPreventer nep)
        {
            return new bool[] { };
        }

        public static implicit operator int(NullExceptionPreventer nep)
        {
            return 0;
        }

        public static implicit operator int?(NullExceptionPreventer nep)
        {
            return null;
        }

        public static implicit operator int[](NullExceptionPreventer nep)
        {
            return new int[] { };
        }

        public static implicit operator long(NullExceptionPreventer nep)
        {
            return 0;
        }

        public static implicit operator long?(NullExceptionPreventer nep)
        {
            return null;
        }

        public static implicit operator long[](NullExceptionPreventer nep)
        {
            return new long[] { };
        }

        public static implicit operator string(NullExceptionPreventer nep)
        {
            return string.Empty;
        }

        public static implicit operator string[](NullExceptionPreventer nep)
        {
            return new string[] { };
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
