using UnityEngine.UIElements;

namespace VisualScript.Editor.Characters
{
    public class SpaceCustom : VisualElement
    {
        public SpaceCustom(int value)
        {
            this.style.height = new StyleLength(value);
        }
    }
}