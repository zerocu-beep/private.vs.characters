using System;
using VisualScript.Runtime.Characters.IK;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Start Looking At")]
    [Description("Starts looking at a target using the Look At IK system")]

    [Category("Characters/IK/Start Looking At")]

    [Parameter("Character", "The character target")]
    [Parameter("Target", "The targeted Transform to look at")]
    [Parameter("Layer", "The priority of this IK over other Look At attempts")]

    [Keywords("Inverse", "Kinematics", "IK")]
    [Image(typeof(IconEye), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterIKLookStart : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectInstance());
        [SerializeField] private int m_Priority = 1;
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"{this.m_Character} look at {this.m_Target}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            Transform target = this.m_Target.Get<Transform>(args);
            if (target == null || !character.IK.HasRig<RigLookTo>()) return Done;

            LookToTransform track = new LookToTransform(
                this.m_Priority, 
                target, 
                Vector3.zero
            );
                
            character.IK.GetRig<RigLookTo>().SetTarget(track);
            return Done;
        }
    }
}