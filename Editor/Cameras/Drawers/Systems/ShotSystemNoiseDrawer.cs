using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;

    [CustomPropertyDrawer(typeof(ShotSystemNoise))]
    public class ShotSystemNoiseDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Noise";
    }
}