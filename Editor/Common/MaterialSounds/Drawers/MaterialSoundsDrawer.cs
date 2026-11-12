using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(MaterialSounds))]
    public class MaterialSoundsDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            
            SerializedProperty soundsAsset = property.FindPropertyRelative("m_SoundsAsset");
            root.Add(new PropertyField(soundsAsset));

            return root;
        }
    }
}
