using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(ShakeEffect))]
    public class ShakeEffectDrawer : TSectionDrawer
    {
        protected override string Name(SerializedProperty property)
        {
            return "Shake Effect";
        }
    }
}