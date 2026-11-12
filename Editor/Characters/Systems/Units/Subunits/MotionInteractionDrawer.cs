using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(MotionInteraction))]
    public class MotionInteractionDrawer : TBoxDrawer
    {
        protected override string Name(SerializedProperty property) => "Interaction";
    }
}