using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Memory for Visual Script's Remember component that stores where a Character is and where
    /// it faces. Unlike the Transform memory, it moves the Character through its Driver, so the
    /// physics and the movement of the Character pick up the new position (as Game Creator's
    /// memories did). Objects without a Character are restored through their Transform.
    /// </summary>
    [Title("Character")]
    [Category("Component/Character")]

    [Image(typeof(IconCharacter), ColorTheme.Type.Lime)]
    [Description("Stores the position and rotation of a Character, and moves it through its Driver when restored")]

    [Keywords("Player", "Position", "Rotation", "Transform", "Location")]

    [Note("Use OnLoad for characters like the Player which can move between scenes")]
    [Note("Use Always for characters that should remember the position when the player returns to the scene")]

    [Serializable]
    public class MemoryCharacter : Memory
    {
        // CLASS: ---------------------------------------------------------------------------------

        [Serializable]
        public class DataCharacter : Data
        {
            [SerializeField] private RestoreMode m_Restore;
            [SerializeField] private Vector3 m_Position;
            [SerializeField] private Quaternion m_Rotation;

            public DataCharacter(MemoryCharacter memory, GameObject gameObject)
            {
                this.m_Restore = memory.m_Restore;

                Character character = gameObject.GetComponent<Character>();

                // the feet of the Character, as Game Creator stored it
                this.m_Position = character != null ? character.Feet : gameObject.transform.position;
                this.m_Rotation = gameObject.transform.rotation;
            }

            public override Awaitable OnLoad(GameObject gameObject)
            {
                if (this.m_Restore != RestoreMode.Always && !SaveLoadManager.IsLoading)
                {
                    return AwaitableUtils.DontAwait;
                }

                Character character = gameObject.GetComponent<Character>();
                if (character != null && character.Driver != null)
                {
                    character.Driver.SetPosition(this.m_Position, true);
                    character.Driver.SetRotation(this.m_Rotation);
                }
                else
                {
                    gameObject.transform.SetPositionAndRotation(this.m_Position, this.m_Rotation);
                }

                return AwaitableUtils.DontAwait;
            }
        }

        // ENUMS: ---------------------------------------------------------------------------------

        private enum RestoreMode
        {
            /// <summary>
            /// Restores the Character on Awake, whether it is caused by loading a scene or by
            /// loading a previously saved game.
            /// </summary>
            Always,

            /// <summary>
            /// Restores the Character only when loading a previously saved game.
            /// </summary>
            OnLoad
        }

        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private RestoreMode m_Restore = RestoreMode.OnLoad;

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string Title => "Character";

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public override Data OnSave(GameObject gameObject)
        {
            return new DataCharacter(this, gameObject);
        }
    }
}
