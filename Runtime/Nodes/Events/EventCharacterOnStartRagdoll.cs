using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Start Ragdoll")]
    [Image(typeof(IconSkeleton), ColorTheme.Type.Blue)]
    
    [Category("Characters/Ragdoll/On Start Ragdoll")]
    [Description("Executed when the character enters the ragdoll mode")]

    [Serializable]
    public class EventCharacterOnStartRagdoll : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Ragdoll.EventAfterStartRagdoll += this.OnRagdoll;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Ragdoll.EventAfterStartRagdoll -= this.OnRagdoll;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnRagdoll()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}