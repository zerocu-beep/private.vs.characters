using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Player Scale")]
    [Category("Characters/Player Scale")]

    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]
    [Description("Scale of the Player character in local or world space")]

    [Get]

    [Serializable]
    public class TypeVector3ScalePlayer : TypeVector3
    {
        [SerializeField] private ScaleSpace m_Space = ScaleSpace.Local;

        public override Vector3 Get(Args args)
        {
            Transform transform = ShortcutPlayer.Transform;
            if (transform == null) return Vector3.one;

            return this.m_Space switch
            {
                ScaleSpace.Local => transform.localScale,
                ScaleSpace.Global => transform.lossyScale,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3ScalePlayer()
        );

        public override string ToString() => $"{this.m_Space} Player";

        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}
