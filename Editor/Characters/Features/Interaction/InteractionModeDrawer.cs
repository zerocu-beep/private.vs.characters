using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    [CustomPropertyDrawer(typeof(VisualScript.Runtime.Characters.InteractionMode))]
    public class InteractionModeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();

            SerializedProperty reference = property.FindPropertyRelative("m_InteractionMode");
            PropertyElement inputElement = new PropertyElement(
                reference,
                property.displayName, 
                false
            );
            
            root.Add(inputElement);
            return root;
        }
    }
}
