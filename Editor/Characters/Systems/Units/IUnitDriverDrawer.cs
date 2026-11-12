using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;
using VisualScript.Icons;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(IUnitDriver), true)]
    public class IUnitDriverDrawer : TUnitDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return this.MakePropertyGUI(property, "Driver");
        }
        
        protected override IIcon UnitIcon => new IconWheel(ColorTheme.Type.TextLight);
    }
}