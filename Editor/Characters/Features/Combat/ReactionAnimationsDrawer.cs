using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(ReactionAnimations))]
    public class ReactionAnimationsDrawer : TArrayDrawer
    {
        protected override string PropertyArrayName => "m_Animations";
        protected override float ItemHeight => 22f;
    }
}