using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(CameraTransition))]
    public class CameraTransitionDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();

            StyleSheet[] styleSheets = StyleSheetUtils.Load();
            foreach (StyleSheet styleSheet in styleSheets)
            {
                root.styleSheets.Add(styleSheet);
            }
            
            SerializedProperty currentShot = property.FindPropertyRelative("m_CurrentShotCamera");
            SerializedProperty smoothPosition = property.FindPropertyRelative("m_SmoothTimePosition");
            SerializedProperty smoothRotation = property.FindPropertyRelative("m_SmoothTimeRotation");
            
            PropertyField fieldCurrentShot = new PropertyField(currentShot);
            PropertyField fieldSmoothPosition = new PropertyField(smoothPosition);
            PropertyField fieldSmoothRotation = new PropertyField(smoothRotation);
            
            root.Add(fieldCurrentShot);
            root.Add(fieldSmoothPosition);
            root.Add(fieldSmoothRotation);

            return root;
        }
    }
}
