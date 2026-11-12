using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using VisualScript.Icons;
using VisualScript.Runtime;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;
    using VisualScript.Runtime.Characters;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(TShotType), true)]
    public class TShotTypeDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            return new TShotTypeElement(property);
        }
    }

    /// <summary>
    /// The shot type of a Shot Camera with Game Creator's design (a full width button with the
    /// icon and name of the shot, and its systems below). The shot is chosen with the Visual
    /// Script type selector.
    /// </summary>
    public sealed class TShotTypeElement : VisualElement
    {
        private const string USS_PATH = EditorPaths.CAMERAS + "StyleSheets/ShotType";

        private const string NAME_ROOT = "GC-Cameras-ShotType-Root";
        private const string NAME_HEAD = "GC-Cameras-ShotType-Head";
        private const string NAME_BODY = "GC-Cameras-ShotType-Body";

        private const string NAME_HEAD_BUTTON = "GC-Cameras-ShotType-Head-Btn";
        private const string NAME_HEAD_BUTTON_ICON = "GC-Cameras-ShotType-Head-BtnIcon";
        private const string NAME_HEAD_BUTTON_LABEL = "GC-Cameras-ShotType-Head-BtnLabel";
        private const string NAME_HEAD_BUTTON_ARROW = "GC-Cameras-ShotType-Head-BtnArrow";

        private static readonly IIcon ICON_ARROW = new IconDropdown(ColorTheme.Type.TextLight);

        // MEMBERS: -------------------------------------------------------------------------------

        private readonly SerializedProperty m_Property;

        private readonly VisualElement m_Body;
        private readonly Image m_ButtonIcon;
        private readonly Label m_ButtonLabel;

        // CONSTRUCTOR: ---------------------------------------------------------------------------

        public TShotTypeElement(SerializedProperty property)
        {
            this.m_Property = property;

            VisualElement root = new VisualElement { name = NAME_ROOT };
            VisualElement head = new VisualElement { name = NAME_HEAD };
            this.m_Body = new VisualElement { name = NAME_BODY };

            this.Add(root);
            root.Add(head);
            root.Add(this.m_Body);

            foreach (StyleSheet sheet in StyleSheetUtils.Load(USS_PATH)) this.styleSheets.Add(sheet);
            this.m_Body.AddToClassList("gc-cameras-shot-type-body");

            Button button = new Button { name = NAME_HEAD_BUTTON };
            this.m_ButtonIcon = new Image { name = NAME_HEAD_BUTTON_ICON };
            this.m_ButtonLabel = new Label { name = NAME_HEAD_BUTTON_LABEL };

            button.Add(this.m_ButtonIcon);
            button.Add(this.m_ButtonLabel);
            button.Add(new Image { image = ICON_ARROW.Texture, name = NAME_HEAD_BUTTON_ARROW });
            button.SetEnabled(!EditorApplication.isPlayingOrWillChangePlaymode);

            button.clicked += () => TypeSelectorWindow.Open(
                button,
                VsFields.GetFieldType(this.m_Property) ?? typeof(TShotType),
                this.m_Property,
                (newType, _) => this.OnChoose(newType)
            );

            head.Add(button);

            this.RefreshHead();
            this.RefreshBody();
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnChoose(Type newType)
        {
            if (newType == null) return;

            this.m_Property.serializedObject.Update();
            this.m_Property.managedReferenceValue = Activator.CreateInstance(newType);
            this.m_Property.serializedObject.ApplyModifiedProperties();

            this.RefreshHead();
            this.RefreshBody();
        }

        private void RefreshHead()
        {
            this.m_Property.serializedObject.Update();

            Type type = TypeUtils.GetTypeFromProperty(this.m_Property, true);
            ImageAttribute image = type?.GetCustomAttributes<ImageAttribute>().FirstOrDefault();

            this.m_ButtonIcon.image = image?.Image;
            this.m_ButtonLabel.text = type != null ? TypeUtils.GetTitleFromType(type) : "(none)";
        }

        private void RefreshBody()
        {
            this.m_Body.Clear();
            this.m_Property.serializedObject.Update();

            SerializationUtils.CreateChildProperties(
                this.m_Body,
                this.m_Property,
                SerializationUtils.ChildrenMode.ShowLabelsInChildren,
                true
            );

            this.m_Body.Bind(this.m_Property.serializedObject);
        }
    }
}
