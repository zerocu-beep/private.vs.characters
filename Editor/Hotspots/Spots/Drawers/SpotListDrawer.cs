using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Hotspots
{
    using VisualScript.Runtime.Hotspots;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(SpotList))]
    public class SpotListDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            SpotListTool spotListTool = new SpotListTool(property);
            return spotListTool;
        }
    }
}