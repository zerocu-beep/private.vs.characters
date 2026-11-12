using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// A position and/or rotation in space. Used by Characters to navigate, teleport and face.
    /// </summary>
    [Title("Location")]
    [Serializable]
    public abstract class TypeLocation : TType<Location>
    { }

    [Title("Get Location")]
    [Category("Get Location")]
    [Image(typeof(IconLocationDrop), ColorTheme.Type.Yellow)]
    [Serializable]
    public class GetLocation : TSignalGet<TypeLocation, Location>
    {
        public GetLocation() : this(new TypeLocationNone())
        { }

        public GetLocation(TypeLocation value) : base(value)
        { }
    }
}
