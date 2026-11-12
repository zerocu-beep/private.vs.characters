using System;
using VisualScript.Runtime.Characters.IK;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Clear Looking Around")]
    [Description("Stops looking at any target that isn't in a Hotspot (priority zero)")]

    [Category("Characters/IK/Clear Looking Around")]

    [Parameter("Character", "The character target")]

    [Keywords("Inverse", "Kinematics", "IK")]
    [Image(typeof(IconEye), ColorTheme.Type.Blue, typeof(BadgeCross))]

    [Serializable]
    public class InstructionCharacterIKLookClear : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"{this.m_Character} stop looking around";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            if (character.IK.HasRig<RigLookTo>())
            {
                character.IK.GetRig<RigLookTo>().ClearTargets();
            }
            
            return Done;
        }
    }
}