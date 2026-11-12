using UnityEditor;
using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    /// <summary>
    /// A polymorphic [SerializeReference] field drawn with the Visual Script ValueField.
    /// Keeps the Game Creator constructor so ported inspectors need no changes.
    /// </summary>
    public class PropertyElement : VisualElement
    {
        public PropertyElement(SerializedProperty property, string label, bool _ = false)
        {
            this.Add(VsFields.Reference(property, label));
        }
    }
}
