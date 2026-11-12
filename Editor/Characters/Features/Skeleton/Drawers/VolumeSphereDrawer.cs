using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(VolumeSphere))]
    public class VolumeSphereDrawer : VolumeDrawer
    {
        protected override void CreateGUI(SerializedProperty property, VisualElement root)
        {
            SerializedProperty center = property.FindPropertyRelative("m_Center");
            SerializedProperty radius = property.FindPropertyRelative("m_Radius");

            PropertyField fieldCenter = new PropertyField(center);
            PropertyField fieldRadius = new PropertyField(radius);

            root.Add(fieldCenter);
            root.Add(fieldRadius);
        }
    }
}