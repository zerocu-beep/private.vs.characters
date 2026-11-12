using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    // Polymorphic [SerializeReference] members that no ported inspector draws explicitly.
    // They get the Visual Script ValueField (type selector + content) like any VS field.

    [CustomPropertyDrawer(typeof(TMarkerType), true)]
    public class TMarkerTypeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return VsFields.Reference(property, property.displayName);
        }
    }

    [CustomPropertyDrawer(typeof(TMunitionValue), true)]
    public class TMunitionValueDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return VsFields.Reference(property, property.displayName);
        }
    }
}
