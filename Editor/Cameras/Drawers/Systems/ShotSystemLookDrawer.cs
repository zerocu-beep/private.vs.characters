using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemLook))]
    public class ShotSystemLookDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Look";
    }
}