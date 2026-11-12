using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Animates a numeric property of a Character with the Visual Script Tween Manager, using a
    /// Visual Script TweenTransition (duration, easing, time mode and whether to wait).
    /// </summary>
    public static class CharacterTween
    {
        public static async Awaitable Run(
            Component target,
            string property,
            float source,
            float value,
            Action<float> setter,
            TweenTransition transition,
            Args args)
        {
            if (target == null) return;

            bool wait = transition.Await;
            bool isComplete = false;

            TweenManager.Run(new TweenInstanceInput<float>(
                target,
                property,
                source,
                value,
                (_, current) => setter(current),
                () => isComplete = true,
                transition.GetDuration(args),
                transition.EaseMode,
                transition.TimeMode
            ));

            if (!wait) return;
            while (!isComplete && target != null && !AppManager.IsExiting)
            {
                await Awaitable.NextFrameAsync();
            }
        }
    }
}
