using UnityEditor;

namespace VisualScript.Editor.Cameras
{
    using VisualScript.Runtime.Cameras;
    using VisualScript.Editor.Characters;

    [CustomPropertyDrawer(typeof(ShotSystemThirdPerson))]
    public class ShotSystemThirdPersonDrawer : TShotSystemDrawer
    {
        protected override string Name(SerializedProperty property) => "Third Person";
    }
    
    [CustomPropertyDrawer(typeof(ShotSystemThirdPerson.Align))]
    public class ShotSystemThirdPersonAlignDrawer : TBoxDrawer
    {
        protected override string Name(SerializedProperty property) => "Align";
    }
}