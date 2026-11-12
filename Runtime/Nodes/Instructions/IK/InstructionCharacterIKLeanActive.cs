using System;
using VisualScript.Runtime.Characters.IK;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Active Lean IK")]
    [Description("Changes the active state of the Character Lean IK")]

    [Category("Characters/IK/Active Lean IK")]

    [Parameter("Character", "The character target")]
    [Parameter("Active", "Whether the IK system is active or not")]

    [Keywords("Inverse", "Kinematics", "IK")]
    [Image(typeof(IconIK), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterIKLeanActive : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] 
        private GetBool m_Active = new GetBool(false);
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Lean IK of {this.m_Character} = {this.m_Active}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            if (character.IK.HasRig<RigLean>())
            {
                bool state = this.m_Active.Get(args);
                character.IK.GetRig<RigLean>().IsActive = state;
            }
            
            return Done;
        }
    }
}