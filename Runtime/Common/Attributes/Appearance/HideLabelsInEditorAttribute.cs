using System;

namespace VisualScript.Runtime.Characters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HideLabelsInEditorAttribute : Attribute
    {
        public bool Hide { get; }

        public HideLabelsInEditorAttribute(bool hide = true)
        {
            this.Hide = hide;
        }
    }
}