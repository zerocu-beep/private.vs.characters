using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemAnchor))]
    public class ShotSystemAnchorDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Anchor";
    }
}