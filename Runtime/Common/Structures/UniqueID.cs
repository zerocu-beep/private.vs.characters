using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// An identifier for an object, with the same two modes as the ID of Visual Script's save
    /// options:
    /// - ID: always the GUID set in the inspector (objects placed in the scene).
    /// - Random ID: a new GUID for each instance when it is first used (objects instantiated at
    ///   runtime from a prefab, so copies never share the same ID).
    /// </summary>
    [Serializable]
    public class UniqueID
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private TypeId m_IdMode = TypeId.ID;
        [SerializeField] private IdString m_SerializedID;

        [NonSerialized] private IdString m_RandomID = IdString.Empty;

        // PROPERTIES: ----------------------------------------------------------------------------

        public TypeId Mode => this.m_IdMode;

        public IdString Get
        {
            get
            {
                if (this.m_IdMode == TypeId.ID) return this.m_SerializedID;

                if (this.m_RandomID.IsEmpty)
                {
                    this.m_RandomID = new IdString(GenerateID());

                    // as Visual Script's Alias: while playing, the inspector shows the ID in use
                    // (play mode changes are discarded when it stops)
                    if (Application.isPlaying) this.m_SerializedID = this.m_RandomID;
                }

                return this.m_RandomID;
            }
        }

        public IdString Set
        {
            set
            {
                this.m_IdMode = TypeId.ID;
                this.m_SerializedID = value;
            }
        }

        // CONSTRUCTOR: ---------------------------------------------------------------------------

        public UniqueID()
        {
            this.m_SerializedID = new IdString(GenerateID());
        }

        public UniqueID(string defaultID)
        {
            defaultID = string.IsNullOrEmpty(defaultID) ? GenerateID() : defaultID;
            this.m_SerializedID = new IdString(defaultID);
        }

        // PUBLIC STATIC METHODS: -----------------------------------------------------------------

        public static string GenerateID() => Guid.NewGuid().ToString("D");

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        public override string ToString() => this.Get.String;

        public override bool Equals(object obj) => this.Get.Equals(obj);
        public override int GetHashCode() => this.Get.GetHashCode();
    }
}
