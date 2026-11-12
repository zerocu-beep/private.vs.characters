using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;

    [Serializable]
    public class ShotSystemFollow : TShotSystem
    {
        public static readonly int ID = nameof(ShotSystemFollow).GetHashCode();
        
        private static readonly Vector3 DEFAULT_DISTANCE = new Vector3(0f, 2f, -3f);

        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Follow = new GetGameObject(new TypeGameObjectPlayer());
        
        [SerializeField] private GetVector3 m_Distance = new GetVector3(DEFAULT_DISTANCE);
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public override int Id => ID;

        public Transform Follow
        {
            set => this.m_Follow = new GetGameObject(new TypeGameObjectInstance(value));
        }
        
        public Vector3 Distance
        {
            set => this.m_Distance = new GetVector3(value);
        }
        
        // PUBLIC METHODS: ------------------------------------------------------------------------

        public override void OnUpdate(TShotType shotType)
        {
            base.OnUpdate(shotType);

            GameObject followValue = this.m_Follow.Get(shotType.Args);
            Vector3 distanceValue = this.m_Distance.Get(shotType.Args);
                
            if (followValue != null)
            {
                shotType.Position = followValue.transform.position + distanceValue;
            }
        }
    }
}