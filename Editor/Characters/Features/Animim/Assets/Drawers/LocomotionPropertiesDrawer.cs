using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(LocomotionProperties))]
    public class LocomotionPropertiesDrawer : TBoxDrawer
    {
        protected override string Name(SerializedProperty property) => "Properties";
    }
}