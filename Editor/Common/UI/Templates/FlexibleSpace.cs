using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    public sealed class FlexibleSpace : VisualElement
    {
        public FlexibleSpace()
        {
            this.style.flexGrow = 1;
        }
    }
}
