using VisualScript.Runtime.Characters.Animim;
using UnityEditor;

namespace VisualScript.Editor.Characters
{
    [CustomPropertyDrawer(typeof(AnimimGraph))]
    public class AnimimGraphDrawer : TSectionDrawer
    {
        protected override string Name(SerializedProperty property)
        {
            return "States & Gestures";
        }
    }
}