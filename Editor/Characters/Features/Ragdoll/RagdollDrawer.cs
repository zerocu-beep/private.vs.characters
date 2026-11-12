using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(Ragdoll))]
    public class RagdollDrawer : TSectionDrawer
    {
        protected override string Name(SerializedProperty property) => "Ragdoll";

        protected override void CreatePropertyContent(VisualElement container, SerializedProperty property)
        {
            SerializedProperty ragdoll = property.FindPropertyRelative("m_Ragdoll");
            PropertyElement ragdollDropdown = new PropertyElement(ragdoll, "Ragdoll", false);

            container.Add(ragdollDropdown);
        }
    }
}
