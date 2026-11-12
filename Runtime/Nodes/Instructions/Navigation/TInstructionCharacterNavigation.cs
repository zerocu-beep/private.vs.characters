using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Parameter("Character", "The game object with the Character target")]

    [Keywords("Character", "Player")]
    [Serializable]
    public abstract class TInstructionCharacterNavigation : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField]
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
    }
}