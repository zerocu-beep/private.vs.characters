using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    // Drawers for the ported types, built on the Visual Script ones so they look and behave
    // exactly like the rest of the Visual Script inspector.

    [CustomPropertyDrawer(typeof(EnablerBool), true)]
    public class EnablerBoolDrawer : EnablerBaseInlineDrawer
    {
        protected override VisualElement CreateFieldValue(SerializedProperty property)
        {
            return new Toggle(string.Empty) { bindingPath = property.propertyPath };
        }
    }

    [CustomPropertyDrawer(typeof(EnablerAngle180), true)]
    public class EnablerAngle180Drawer : EnablerBaseInlineDrawer
    {
        protected override VisualElement CreateFieldValue(SerializedProperty property)
        {
            return new Slider(string.Empty, 0f, EnablerAngle180.MAX)
            {
                bindingPath = property.propertyPath,
                showInputField = true
            };
        }
    }

    [CustomPropertyDrawer(typeof(EnablerProjection), true)]
    public class EnablerProjectionDrawer : EnablerBaseInlineDrawer
    {
        protected override VisualElement CreateFieldValue(SerializedProperty property)
        {
            return new EnumField(string.Empty, EnablerProjection.Type.Perspective)
            {
                bindingPath = property.propertyPath
            };
        }
    }

    /// <summary>
    /// Shows the Visual Script Time Mode dropdown in a single line, labeled with the field name.
    /// </summary>
    [CustomPropertyDrawer(typeof(CharacterTime))]
    public class CharacterTimeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            SerializedProperty mode = property.FindPropertyRelative("m_UpdateTime");
            return new PropertyField(mode, property.displayName);
        }
    }
}
