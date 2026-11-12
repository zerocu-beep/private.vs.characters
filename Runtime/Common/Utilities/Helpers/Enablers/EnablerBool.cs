using System;

namespace VisualScript.Runtime.Characters
{
    [Serializable]
    public class EnablerBool : TEnablerInline<bool>
    {
        public EnablerBool() : base(false, true)
        { }

        public EnablerBool(bool value) : base(false, value)
        { }

        public EnablerBool(bool isEnabled, bool value) : base(isEnabled, value)
        { }
    }
}
