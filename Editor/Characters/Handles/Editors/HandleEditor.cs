using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomEditor(typeof(Handle))]
    public class HandleEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();
            
            SerializedProperty handles = this.serializedObject.FindProperty("m_Handles");
            
            root.Add(new SpaceSmaller());
            root.Add(new HandleListTool(handles));

            return root;
        }
    }
}