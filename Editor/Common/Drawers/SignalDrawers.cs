using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using VisualScript.Runtime;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(GetLocation))]
    public class SignalGetLocationDrawer : SignalDrawerGet<TypeLocation>
    { }

    /// <summary>
    /// A Game Object signal used as a prefab, followed by its pooling options.
    /// </summary>
    [CustomPropertyDrawer(typeof(GetInstantiate))]
    public class SignalGetInstantiateDrawer : SignalDrawerGet<TypeGameObject>
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement root = new VisualElement();
            root.Add(base.CreatePropertyGUI(property));

            SerializedProperty usePooling = property.FindPropertyRelative("usePooling");
            SerializedProperty size = property.FindPropertyRelative("size");
            SerializedProperty hasDuration = property.FindPropertyRelative("hasDuration");
            SerializedProperty duration = property.FindPropertyRelative("duration");

            VisualElement pooling = new VisualElement { style = { paddingLeft = 15 } };
            PropertyField fieldSize = new PropertyField(size, "Pool Size");
            PropertyField fieldDuration = new PropertyField(duration, "Duration");

            pooling.Add(new PropertyField(usePooling, "Use Pooling"));
            pooling.Add(fieldSize);
            pooling.Add(new PropertyField(hasDuration, "Has Duration"));
            pooling.Add(fieldDuration);
            root.Add(pooling);

            void Refresh()
            {
                property.serializedObject.Update();
                fieldSize.style.display = usePooling.boolValue ? DisplayStyle.Flex : DisplayStyle.None;
                fieldDuration.style.display = hasDuration.boolValue ? DisplayStyle.Flex : DisplayStyle.None;
            }

            root.TrackPropertyValue(usePooling, _ => Refresh());
            root.TrackPropertyValue(hasDuration, _ => Refresh());
            Refresh();

            return root;
        }
    }

    /// <summary>
    /// Instruction lists of Character features (States, Weapons, Reactions...) are drawn with
    /// the Visual Script Instructions editor.
    /// </summary>
    [CustomPropertyDrawer(typeof(RunInstructionsList))]
    public class RunInstructionsListDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return new PropertyField(property.FindPropertyRelative("m_Instructions"), property.displayName);
        }
    }

    [CustomPropertyDrawer(typeof(RunConditionsList))]
    public class RunConditionsListDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return new PropertyField(property.FindPropertyRelative("m_Conditions"), property.displayName);
        }
    }
}
