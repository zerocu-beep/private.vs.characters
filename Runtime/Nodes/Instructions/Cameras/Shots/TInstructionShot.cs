using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Parameter("Shot", "The camera Shot targeted")]
    [Keywords("Cameras", "Shot")]

    [Serializable]
    public abstract class TInstructionShot : Instruction
    {
        [SerializeField] protected GetGameObject m_Shot = TypeGameObjectShot.Create;
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected abstract int SystemID { get; }
        
        // METHODS: -------------------------------------------------------------------------------

        protected T GetShotSystem<T>(Args args) where T : class, IShotSystem
        {
            ShotCamera shot = this.m_Shot.Get<ShotCamera>(args);
            return shot != null ? shot.ShotType.GetSystem(this.SystemID) as T : null;
        }
    }
}