using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;
using VisualScript.Icons;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(IUnitPlayer), true)]
    public class IUnitPlayerDrawer : TUnitDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return this.MakePropertyGUI(property, "Player");
        }
        
        protected override IIcon UnitIcon => new IconPlayer(ColorTheme.Type.TextLight);
    }
}