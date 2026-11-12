using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemFollow))]
    public class ShotSystemFollowDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Follow";
    }
}