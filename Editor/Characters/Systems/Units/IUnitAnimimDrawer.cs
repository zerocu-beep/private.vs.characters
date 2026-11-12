using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;
using VisualScript.Icons;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(IUnitAnimim), true)]
    public class IUnitAnimimDrawer : TUnitDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return this.MakePropertyGUI(property, "Animation");
        }

        protected override void OnBuildBody(VisualElement body, SerializedProperty property)
        {
            base.OnBuildBody(body, property);
            
            ModelTool modelTool = new ModelTool(property);
            body.Add(modelTool);
        }
        
        protected override IIcon UnitIcon => new IconCharacterRun(ColorTheme.Type.TextLight);
    }
}