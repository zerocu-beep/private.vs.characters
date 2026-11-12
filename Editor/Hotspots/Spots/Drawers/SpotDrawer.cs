using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Hotspots
{
    using VisualScript.Runtime.Hotspots;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(Spot), true)]
    public class SpotDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();
            SerializationUtils.CreateChildProperties(
                container,
                property,
                SerializationUtils.ChildrenMode.ShowLabelsInChildren,
                true
            );

            return container;
        }
    }
}