using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomPropertyDrawer(typeof(InverseKinematics))]
    public class InverseKinematicsDrawer : TSectionDrawer
    {
        protected override string Name(SerializedProperty property) => "Inverse Kinematics";
    }
}