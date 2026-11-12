using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Player Position")]
    [Category("Characters/Player Position")]

    [Image(typeof(IconPlayer), ColorTheme.Type.Green)]
    [Description("Returns the position of the Player character")]

    [Get]

    [Serializable]
    public class TypeVector3PositionPlayer : TypeVector3
    {
        public override Vector3 Get(Args args)
        {
            Transform transform = ShortcutPlayer.Transform;
            return transform != null ? transform.position : default;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3PositionPlayer()
        );

        public override string ToString() => "Player";

        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}
