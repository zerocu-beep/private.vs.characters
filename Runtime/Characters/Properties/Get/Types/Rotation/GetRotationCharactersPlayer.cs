using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Player Rotation")]
    [Category("Characters/Player Rotation")]

    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]
    [Description("Rotation of the Player character in local or world space")]

    [Get]

    [Serializable]
    public class TypeQuaternionRotationPlayer : TypeQuaternion
    {
        [SerializeField] private RotationSpace m_Space = RotationSpace.Global;

        public override Quaternion Get(Args args)
        {
            Transform transform = ShortcutPlayer.Transform;
            if (transform == null) return default;

            return this.m_Space switch
            {
                RotationSpace.Local => transform.localRotation,
                RotationSpace.Global => transform.rotation,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static GetQuaternion Create => new GetQuaternion(
            new TypeQuaternionRotationPlayer()
        );

        public override string ToString() => $"{this.m_Space} Player";

        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}
