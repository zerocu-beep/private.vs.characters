using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Game Creator style helpers: resolve a Signal using a game object as both Source and
    /// Target, which is what Character features do when they have no Args at hand.
    /// </summary>
    public static class SignalExtensions
    {
        public static GameObject Get(this GetGameObject signal, GameObject source)
        {
            using Args args = Args.Get(source, source);
            return signal.Get(args);
        }

        public static GameObject Get(this GetGameObject signal, Component source)
        {
            return signal.Get(source != null ? source.gameObject : null);
        }

        public static T Get<T>(this GetGameObject signal, GameObject source) where T : Component
        {
            using Args args = Args.Get(source, source);
            return signal.Get<T>(args);
        }

        public static T Get<T>(this GetGameObject signal, Component source) where T : Component
        {
            return signal.Get<T>(source != null ? source.gameObject : null);
        }

        public static I Get<I>(this ISignalGet<I> signal, GameObject source)
        {
            using Args args = Args.Get(source, source);
            return signal.Get(args);
        }

        public static I Get<I>(this ISignalGet<I> signal, Component source)
        {
            return signal.Get(source != null ? source.gameObject : null);
        }

        public static void ChangeTarget(this Args args, GameObject target)
        {
            args.SetTarget(target);
        }

        public static void ChangeTarget(this Args args, Component target)
        {
            args.SetTarget(target != null ? target.gameObject : null);
        }
    }
}
