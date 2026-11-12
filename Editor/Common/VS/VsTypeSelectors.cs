using System;
using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    /// <summary>
    /// The "Add ..." button of Game Creator's polymorphic lists (IK Rigs, Volumes, Handles).
    /// The list keeps its Game Creator design; the type is chosen with the Visual Script
    /// type selector.
    /// </summary>
    public abstract class TypeSelectorListFancy
    {
        private readonly SerializedProperty m_PropertyList;
        private readonly Type m_Type;

        public event Action<Type, Type> EventChange;

        protected TypeSelectorListFancy(SerializedProperty propertyList, Type type, Button element)
        {
            this.m_PropertyList = propertyList;
            this.m_Type = type;

            element.clicked += () => TypeSelectorWindow.Open(
                element,
                this.m_Type,
                this.m_PropertyList,
                (newType, _) =>
                {
                    if (newType != null) this.EventChange?.Invoke(null, newType);
                }
            );
        }
    }
}
