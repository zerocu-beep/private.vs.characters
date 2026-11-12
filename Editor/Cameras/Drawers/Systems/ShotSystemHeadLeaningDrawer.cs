using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemHeadLeaning))]
    public class ShotSystemHeadLeaningDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Head Leaning";
    }
}