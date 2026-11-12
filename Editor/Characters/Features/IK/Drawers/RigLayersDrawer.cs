using VisualScript.Runtime.Characters.IK;
using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    [CustomPropertyDrawer(typeof(RigLayers))]
    public class RigLayersDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            RigLayersTool rigLayersTool = new RigLayersTool(
                property
            );
            
            return rigLayersTool;
        }
    }
}
