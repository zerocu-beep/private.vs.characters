using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Parameter("Character", "The game object with the Character target")]

    [Serializable]
    public abstract class TInstructionCharacterProperty : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
    }
}