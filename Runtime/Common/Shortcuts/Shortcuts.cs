using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Keeps track of the Character marked as Player.
    /// </summary>
    public static class ShortcutPlayer
    {
        #if UNITY_EDITOR
        [UnityEditor.InitializeOnEnterPlayMode]
        private static void InitializeOnEnterPlayMode()
        {
            Instance = null;
            EventChange = null;
        }
        #endif

        // PROPERTIES: ----------------------------------------------------------------------------

        public static GameObject Instance { get; private set; }

        public static Transform Transform => Instance != null ? Instance.transform : null;

        // EVENTS: --------------------------------------------------------------------------------

        /// <summary>
        /// Executed every time a different game object becomes the Player
        /// </summary>
        public static event Action EventChange;

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public static TComponent Get<TComponent>() where TComponent : Component
        {
            return Instance != null ? Instance.GetComponent<TComponent>() : null;
        }

        public static void Change(GameObject player)
        {
            if (Instance == player) return;

            Instance = player;
            EventChange?.Invoke();
        }
    }
}
