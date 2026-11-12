using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemFirstPerson))]
    public class ShotSystemFirstPersonDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "First Person";
    }
}