namespace BugJumper.Models
{
    using System.Dynamic;

    /// <summary>
    /// This partial implementation of ConfigurationData implements DynamicObject
    /// </summary>
    public partial class ConfigurationData
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (members.ContainsKey(binder.Name))
            {
                result = members[binder.Name];
            }
            else
            {
                result = new NullExceptionPreventer();
            }

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (this.members.ContainsKey(binder.Name))
            {
                this.members[binder.Name] = value;
            }
            else
            {
                //TODO: Should return this result? Would cause more Runtime expections, but less lying to consumers.
                this.members.TryAdd(binder.Name, value);
            }

            return true;
        }
    }
}