using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("On Recover Ragdoll")]
    [Image(typeof(IconSkeleton), ColorTheme.Type.Green)]
    
    [Category("Characters/Ragdoll/On Recover Ragdoll")]
    [Description("Executed when the character recovers from the ragdoll mode")]

    [Serializable]
    public class EventCharacterOnRecoverRagdoll : TEventCharacter
    {
        protected override void WhenEnabled(Character character)
        {
            character.Ragdoll.EventAfterStartRecover += this.OnRagdoll;
        }

        protected override void WhenDisabled(Character character)
        {
            character.Ragdoll.EventAfterStartRecover -= this.OnRagdoll;
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void OnRagdoll()
        {
            Character character = this.m_CurrentSource;
            if (character != null) this.Execute(character.gameObject);
        }
    }
}