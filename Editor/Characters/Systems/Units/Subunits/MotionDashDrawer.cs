using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(MotionDash))]
    public class MotionDashDrawer : TBoxDrawer
    {
        protected override string Name(SerializedProperty property) => "Dash";
    }
}