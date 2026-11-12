using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Editor.Characters;

    public abstract class TShotSystemDrawer : TBoxDrawer
    {
        // OVERRIDE METHODS: ----------------------------------------------------------------------
        
        protected override void CreatePropertyContent(VisualElement root, SerializedProperty property)
        {
            SerializationUtils.CreateChildProperties(
                root,
                property,
                SerializationUtils.ChildrenMode.ShowLabelsInChildren,
                true
            );
        }
    }
}