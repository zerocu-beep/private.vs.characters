using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Set Character Driver")]
    [Description("Changes the driver behavior of the Character")]

    [Category("Characters/Navigation/Set Character Driver")]

    [Parameter("Character", "The Character that changes its Driver behavior")]
    [Parameter("Driver", "The Driver behavior that decides how the Character moves")]

    [Keywords("Character", "Drive", "Controller", "Navmesh", "Agent", "Rigidbody")]
    [Image(typeof(IconWheel), ColorTheme.Type.Green)]

    [Serializable]
    public class InstructionCharacterNavigationDriver : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private UnitDriver m_Driver = new UnitDriver();

        protected override string GetTitle(GameObject source) => 
            $"Change Driver on {this.m_Character} to {this.m_Driver}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            if (this.m_Driver.Wrapper.GetType() != character.Driver.GetType())
            {
                character.Kernel.ChangeDriver(character, this.m_Driver.Wrapper);
            }
            
            return Done;
        }
    }
}