using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;
using VisualScript.Icons;
using UnityEditor.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(IUnitMotion), true)]
    public class IUnitMotionDrawer : TUnitDrawer
    {
        private const string PROPERTY_INTERACTION = "m_Interaction";

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return this.MakePropertyGUI(property, "Motion");
        }
        
        protected override IIcon UnitIcon => new IconChip(ColorTheme.Type.TextLight);
        
        // OVERRIDE METHODS: ----------------------------------------------------------------------
        
        protected override void BuildBody(VisualElement body, SerializedProperty property)
        {
            body.Clear();
            
            SerializationUtils.CreateChildProperties(
                body,
                property,
                SerializationUtils.ChildrenMode.ShowLabelsInChildren, 
                true,
                PROPERTY_INTERACTION
            );
            
            SerializedProperty interaction = property.FindPropertyRelative(PROPERTY_INTERACTION);
            body.Add(new PropertyField(interaction));

            body.Bind(property.serializedObject);
            this.OnBuildBody(body, property);
        }
    }
}