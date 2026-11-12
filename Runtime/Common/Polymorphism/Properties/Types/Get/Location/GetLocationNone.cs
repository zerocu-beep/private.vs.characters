using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("None")]
    [Category("None")]
    
    [Image(typeof(IconNull), ColorTheme.Type.TextLight)]
    [Description("A location with an unspecified position and location")]

    [Get]

    [Serializable]
    public class TypeLocationNone : TypeLocation
    {
        public override Location Get(Args args) => Location.None;
        public Location Get(GameObject gameObject) => Location.None;

        public static GetLocation Create => new GetLocation(
            new TypeLocationNone()
        );

        public override string ToString() => "(none)";
    }
}