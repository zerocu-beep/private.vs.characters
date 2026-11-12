using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemLockOn))]
    public class ShotSystemLockOnDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Lock On";
    }
}