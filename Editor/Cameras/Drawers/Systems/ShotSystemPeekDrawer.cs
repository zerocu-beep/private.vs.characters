using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemPeek))]
    public class ShotSystemPeekDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Peek";
    }
}