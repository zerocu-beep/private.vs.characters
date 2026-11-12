using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Parameter("Character", "The Character instance referenced in the condition")]
    
    [Keywords("Character", "Player")]
    
    [Serializable]
    public abstract class TConditionCharacter : Condition
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        protected GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
    }
}
