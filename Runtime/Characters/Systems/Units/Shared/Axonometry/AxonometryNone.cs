using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("None")]
    [Category("None")]

    [Image(typeof(IconEmpty), ColorTheme.Type.TextNormal)]
    [Description("Do not use any kind of axonometric processing")]

    [Serializable]
    public class AxonometryNone : TAxonometry
    {
        // CLONE: ---------------------------------------------------------------------------------

        public override object Clone()
        {
            return new AxonometryNone();
        }
        
        // STRING: --------------------------------------------------------------------------------
        
        public override string ToString() => "None";
    }
}