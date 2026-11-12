using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemHeadBobbing))]
    public class ShotSystemHeadBobbingDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Head Bobbing";
    }
}