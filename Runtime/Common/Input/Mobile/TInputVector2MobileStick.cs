using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// A Vector2 input read from an on-screen touch stick (mobile joystick). The stick is
    /// created the first time the input is enabled, shown while enabled and destroyed with it.
    /// </summary>
    [Serializable]
    public abstract class TInputVector2MobileStick : InputVector2Base
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        [field: NonSerialized] protected ITouchStick Stick { get; set; }

        // INITIALIZERS: --------------------------------------------------------------------------

        protected override void OnEnable()
        {
            this.Stick ??= this.CreateTouchStick();
            if (this.Stick?.Root != null) this.Stick.Root.SetActive(true);
        }

        protected override void OnDisable()
        {
            if (this.Stick?.Root != null) this.Stick.Root.SetActive(false);
        }

        protected override void OnDestroy()
        {
            if (this.Stick?.Root != null) UnityEngine.Object.Destroy(this.Stick.Root);
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public override Vector2 Read()
        {
            return this.Stick?.Value ?? Vector2.zero;
        }

        // ABSTRACT METHODS: ----------------------------------------------------------------------

        protected abstract ITouchStick CreateTouchStick();
    }
}
