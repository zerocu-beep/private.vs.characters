using System;
using System.Reflection;
using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    /// <summary>
    /// Builds Visual Script editor fields for ported members. Every polymorphic
    /// [SerializeReference] member is drawn with the Visual Script ValueField and its type
    /// selector, exactly like Visual Script draws its own polymorphic fields.
    /// </summary>
    public static class VsFields
    {
        private static readonly ValueConfig CONFIG = new ValueConfig
        {
            showContextMenu = true,
            canCopyPaste = true,
            canToggleContent = true,
            startContentOpen = true,
            hasHelp = true,
            isLarge = false,
            indentContent = true,
            filterItems = null,
            content = null,
            type = VisualScript.Editor.ValueType.None,
        };

        /// <summary>
        /// The declared type of a [SerializeReference] field (the base type to choose from).
        /// </summary>
        public static Type GetFieldType(SerializedProperty property)
        {
            string typename = property?.managedReferenceFieldTypename;
            if (string.IsNullOrEmpty(typename)) return null;

            int split = typename.IndexOf(' ');
            if (split < 0) return null;

            string assembly = typename.Substring(0, split);
            string type = typename.Substring(split + 1);
            return Type.GetType($"{type}, {assembly}");
        }

        /// <summary>
        /// A Visual Script polymorphic field (type selector + content) for a
        /// [SerializeReference] property.
        /// </summary>
        public static VisualElement Reference(
            SerializedProperty property,
            string label,
            Action<VisualElement, SerializedProperty> content = null)
        {
            Type baseType = GetFieldType(property) ?? typeof(object);

            ValueConfig config = CONFIG;
            config.content = content;

            Type fieldType = typeof(ValueField<>).MakeGenericType(baseType);
            MethodInfo create = fieldType.GetMethod(
                "Create",
                BindingFlags.Public | BindingFlags.Static,
                null,
                new[] { typeof(string), typeof(SerializedProperty), typeof(ValueConfig) },
                null
            );

            return create?.Invoke(null, new object[] { label, property, config }) as VisualElement
                   ?? new UnityEditor.UIElements.PropertyField(property, label);
        }

        /// <summary>
        /// A Visual Script content list for an array of [SerializeReference] items. When the
        /// base type has no subclasses, items are created directly (no type selector).
        /// </summary>
        public static VisualElement List(SerializedProperty arrayProperty, Type baseType)
        {
            bool polymorphic = baseType.IsAbstract || TypeCache.GetTypesDerivedFrom(baseType).Count > 0;

            return polymorphic
                ? new ContentListFieldProperty(arrayProperty, baseType, true, true)
                : new ContentSingleListFieldProperty(arrayProperty, baseType, true);
        }
    }
}
