using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemViewport))]
    public class ShotSystemViewportDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Viewport";
    }
}