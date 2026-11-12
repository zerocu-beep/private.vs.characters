using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Mannequin Scale")]
    [Description("Changes the local scale of the Mannequin object within the Character")]

    [Category("Characters/Properties/Mannequin Scale")]

    [Parameter("Character", "The character target")]
    [Parameter("Scale", "The Local Scale of the Mannequin")]
    
    [Keywords("Location", "Model", "Local")]
    [Image(typeof(IconBust), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterPropertyMannequinScale : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [Space] [SerializeField]
        private GetVector3 m_Scale = new GetVector3();

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Mannequin Scale {this.m_Character} = {this.m_Scale}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;
            
            Vector3 value = this.m_Scale.Get(args);
            
            character.Animim.Scale = value;
            character.Animim.ApplyMannequinScale();
            
            return Done;
        }
    }
}