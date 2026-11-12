using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(MotionJump))]
    public class MotionJumpDrawer : TBoxDrawer
    {
        protected override string Name(SerializedProperty property) => "Jump";
    }
}