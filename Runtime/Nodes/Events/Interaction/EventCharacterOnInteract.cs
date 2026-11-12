using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Makes its game object an interactive one: Characters can focus it and interact with it
    /// (for example with the Interact instruction of the Player). Runs when a Character
    /// interacts, and the interaction ends when the Event finishes its instructions.
    /// </summary>
    [Title("On Interact")]
    [Category("Interactive/On Interact")]
    [Description("Executed when a Character interacts with this object")]

    [Image(typeof(IconCharacterInteract), ColorTheme.Type.Green)]
    [Keywords("Interaction", "Use", "Talk", "Pick", "Open")]

    [Parameter("From Character", "Any Character, or a Specific one that is the only one able to interact")]
    [Parameter("Use Raycast", "When enabled, checks that there is nothing between the Character and this object")]

    [Serializable]
    public class EventCharacterOnInteract : Trigger
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private TValueOrAny<GetGameObject> m_FromCharacter = new TValueOrAny<GetGameObject>(
            ValueOrAny.Any,
            new GetGameObject(new TypeGameObjectPlayer())
        );
        [SerializeField] private EnablerLayerMask m_UseRaycast = new EnablerLayerMask(false, Physics.DefaultRaycastLayers);

        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private InteractionTracker m_Tracker;
        [NonSerialized] private IInteractive m_Interactive;

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source)
        {
            string member = TextUtils.ThemeAsKeyword("Interact");
            return this.m_FromCharacter.IsSpecific
                ? $"{member} from {this.m_FromCharacter.Value}"
                : member;
        }

        // INITIALIZERS: --------------------------------------------------------------------------

        public override void OnEnable()
        {
            base.OnEnable();
            if (this.Component == null) return;

            this.m_Tracker = InteractionTracker.Require(this.Component.gameObject);
            this.m_Tracker.EventInteract -= this.OnInteract;
            this.m_Tracker.EventInteract += this.OnInteract;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (this.m_Tracker != null) this.m_Tracker.EventInteract -= this.OnInteract;
            this.StopInteraction();
        }

        // CALLBACKS: -----------------------------------------------------------------------------

        private void OnInteract(Character character, IInteractive interactive)
        {
            this.m_Interactive = interactive;

            if (!this.CanInteract(character))
            {
                this.StopInteraction();
                return;
            }

            VisualScript.Runtime.Event eventComponent = this.Component as VisualScript.Runtime.Event;
            if (eventComponent != null)
            {
                eventComponent.EventInstructionEndRunning -= this.StopInteraction;
                eventComponent.EventInstructionEndRunning += this.StopInteraction;
            }

            using Args args = Args.Get(this.Component, character.gameObject);
            this.Run(args);

            // nothing left running (no instructions, or they finished at once): end it now
            if (eventComponent == null || !eventComponent.IsRunning) this.StopInteraction();
        }

        private bool CanInteract(Character character)
        {
            if (character == null) return false;

            if (this.m_FromCharacter.IsSpecific)
            {
                using Args args = Args.Get(this.Component, character.gameObject);
                if (this.m_FromCharacter.Value.Get(args) != character.gameObject) return false;
            }

            if (this.m_UseRaycast.IsEnabled && this.HasObstacle(character)) return false;
            return true;
        }

        private bool HasObstacle(Character character)
        {
            Vector3 from = character.transform.position + Vector3.up * (character.Motion.Height * 0.5f);
            Vector3 to = this.Component.transform.position;

            RaycastHit[] hits = Physics.RaycastAll(
                from, (to - from).normalized, Vector3.Distance(from, to),
                this.m_UseRaycast.Value, QueryTriggerInteraction.Ignore
            );

            foreach (RaycastHit hit in hits)
            {
                if (hit.transform.IsChildOf(character.transform)) continue;
                if (hit.transform.IsChildOf(this.Component.transform)) continue;
                return true;
            }

            return false;
        }

        private void StopInteraction()
        {
            if (this.Component is VisualScript.Runtime.Event eventComponent)
            {
                eventComponent.EventInstructionEndRunning -= this.StopInteraction;
            }

            this.m_Interactive?.Stop();
            this.m_Interactive = null;
        }
    }
}
