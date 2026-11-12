using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Mannequin Rotation")]
    [Description("Changes the local rotation of the Mannequin object within the Character")]

    [Category("Characters/Properties/Mannequin Rotation")]

    [Parameter("Character", "The character target")]
    [Parameter("Rotation", "The Local Rotation of the Mannequin")]
    
    [Keywords("Location", "Model", "Local")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyMannequinRotation : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] [SerializeField]
        private GetQuaternion m_Rotation = new GetQuaternion();

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Mannequin Rotation {this.m_Character} = {this.m_Rotation}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            Quaternion value = this.m_Rotation.Get(args);
            
            character.Animim.Rotation = value;
            character.Animim.ApplyMannequinRotation();
            
            return Done;
        }
    }
}