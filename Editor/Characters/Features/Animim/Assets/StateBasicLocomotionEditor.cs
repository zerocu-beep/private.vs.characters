using UnityEditor;

namespace VisualScript.Editor.Characters
{
    using VisualScript.Runtime.Characters;

    [CustomEditor(typeof(StateBasicLocomotion))]
    public class StateBasicLocomotionEditor : StateTLocomotionEditor
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string NameOfStand => "m_Stand8Points";
        
        protected override string NameOfLand => "m_Land8Points";

        // CREATE STATE: --------------------------------------------------------------------------

        [MenuItem("Assets/Create/Visual Script/Characters/Basic Locomotion State", false, 0)]
        internal static void CreateFromMenuItem()
        {
            StateBasicLocomotion state = CreateState<StateBasicLocomotion>(
                "Basic Locomotion State",
                RuntimePaths.CHARACTERS + "Assets/Overrides/BasicLocomotion.overrideController"
            );
            
            state.name = "Basic Locomotion State";
        }
    }
}