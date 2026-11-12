using UnityEditor;
using UnityEngine.UIElements;
using VisualScript.Runtime;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    /// <summary>
    /// A Unique ID drawn like the ID part of Visual Script's save options: an "ID / Random ID"
    /// selector and, in ID mode, the Visual Script ID field with the button to regenerate it.
    /// Uses Visual Script's own style sheet and classes for that row.
    /// </summary>
    [CustomPropertyDrawer(typeof(UniqueID))]
    public class UniqueIDDrawer : PropertyDrawer
    {
        private const string USS_PATH = PathUtils.Core + "Editor/StyleSheets/SaveOptions.uss";

        private const string CLASS_OPTIONS = "vs-save-options";
        private const string CLASS_OPTIONS_TYPE_ID = "vs-save-options__type-id";
        private const string CLASS_OPTIONS_ID = "vs-save-options__id";

        private static readonly IdStringConfig CONFIG = new IdStringConfig
        {
            prefix = IdStringConfig.Prefix.None,
            edition = IdStringConfig.Edition.EditGuidButton,
            marginTop = false,
            inspectorMargins = false,
            requireUniqueId = true
        };

        // in Play, as Visual Script's Alias: the ID in use, read only, with the ID icon
        private static readonly IdStringConfig CONFIG_RUNTIME = new IdStringConfig
        {
            prefix = IdStringConfig.Prefix.PrefixIconId,
            edition = IdStringConfig.Edition.ReadOnly,
            marginTop = false,
            inspectorMargins = false,
            requireUniqueId = false
        };

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode)
            {
                SerializedProperty runtimeId = property.FindPropertyRelative("m_SerializedID");
                return new IdStringElement(string.Empty, runtimeId, CONFIG_RUNTIME);
            }

            VisualElement root = new VisualElement();
            root.LoadStyleSheet(USS_PATH);
            root.AddToClassList(CLASS_OPTIONS);

            SerializedProperty idMode = property.FindPropertyRelative("m_IdMode");
            SerializedProperty id = property.FindPropertyRelative("m_SerializedID");

            EnumField fieldIdMode = new EnumField
            {
                label = string.Empty,
                bindingPath = idMode.propertyPath
            };

            IdStringElement fieldId = new IdStringElement(string.Empty, id, CONFIG);

            fieldIdMode.AddToClassList(CLASS_OPTIONS_TYPE_ID);
            fieldId.AddToClassList(CLASS_OPTIONS_ID);

            Refresh((TypeId) idMode.enumValueIndex, fieldIdMode, fieldId);
            fieldIdMode.RegisterValueChangedCallback(changeEvent =>
            {
                if (changeEvent.newValue is TypeId typeId) Refresh(typeId, fieldIdMode, fieldId);
            });

            root.Add(fieldIdMode);
            root.Add(fieldId);

            return root;
        }

        // as Visual Script does: the ID field only shows in ID mode, and in Random ID mode the
        // selector takes the whole row
        private static void Refresh(TypeId typeId, VisualElement fieldIdMode, VisualElement fieldId)
        {
            fieldId.style.display = typeId == TypeId.ID ? DisplayStyle.Flex : DisplayStyle.None;
            fieldIdMode.style.flexGrow = typeId == TypeId.RandomID ? 1f : 0f;
        }
    }
}
