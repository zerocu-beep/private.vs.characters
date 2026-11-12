using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// An optional angle between 0 and 179 degrees. A Visual Script inline enabler.
    /// </summary>
    [Serializable]
    public class EnablerAngle180 : TEnablerInline<float>
    {
        public const float MAX = 179f;

        public new float Value
        {
            get => Mathf.Clamp(base.Value, 0f, MAX);
            set => base.Value = Mathf.Clamp(value, 0f, MAX);
        }

        public EnablerAngle180() : base(false, 60f)
        { }

        public EnablerAngle180(float value) : base(false, Mathf.Clamp(value, 0f, MAX))
        { }

        public EnablerAngle180(bool isEnabled, float value) : base(isEnabled, Mathf.Clamp(value, 0f, MAX))
        { }
    }

    /// <summary>
    /// An optional camera projection. A Visual Script inline enabler.
    /// </summary>
    [Serializable]
    public class EnablerProjection : TEnablerInline<EnablerProjection.Type>
    {
        public enum Type
        {
            Perspective,
            Orthographic
        }

        public EnablerProjection() : base(false, Type.Perspective)
        { }

        public EnablerProjection(Type value) : base(false, value)
        { }

        public EnablerProjection(bool isEnabled, Type value) : base(isEnabled, value)
        { }
    }
}
