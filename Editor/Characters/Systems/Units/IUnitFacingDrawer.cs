using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;
using VisualScript.Icons;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(IUnitFacing), true)]
    public class IUnitFacingDrawer : TUnitDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return this.MakePropertyGUI(property, "Rotation");
        }
        
        protected override IIcon UnitIcon => new IconRotationYaw(ColorTheme.Type.TextLight);
    }
}