using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Mannequin Position")]
    [Description("Changes the local position of the Mannequin object within the Character")]

    [Category("Characters/Properties/Mannequin Position")]

    [Parameter("Character", "The character target")]
    [Parameter("Position", "The Local Position of the Mannequin")]
    
    [Keywords("Location", "Model", "Local", "Change", "Set", "Root")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyMannequinPosition : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] [SerializeField]
        private GetVector3 m_Position = new GetVector3();

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Mannequin Position {this.m_Character} = {this.m_Position}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            Vector3 value = this.m_Position.Get(args);
            
            character.Animim.Position = value;
            character.Animim.ApplyMannequinPosition();
            
            return Done;
        }
    }
}