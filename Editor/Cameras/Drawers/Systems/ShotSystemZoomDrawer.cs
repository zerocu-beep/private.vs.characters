using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemZoom))]
    public class ShotSystemZoomDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Zoom";
    }
}