using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;

    [Serializable]
    public class ShotSystemAnchor : TShotSystem
    {
        public static readonly int ID = nameof(ShotSystemAnchor).GetHashCode();
        
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectPlayer());
        [SerializeField] private GetVector3 m_Offset = TypeVector3DirectionLocalValue.CreateTarget();

        [SerializeField] private GetVector3 m_Distance = TypeVector3DirectionLocalValue.CreateTarget(
            new Vector3(0f, 0f, -3f)
        );
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public override int Id => ID;

        public GameObject Target
        {
            set => this.m_Target = new GetGameObject(new TypeGameObjectInstance(value));
        }
        
        public Vector3 Offset
        {
            set => this.m_Offset = TypeVector3DirectionLocalValue.CreateTarget(value);
        }
        
        public Vector3 Distance
        {
            set => this.m_Distance = TypeVector3DirectionLocalValue.CreateTarget(value);
        }

        // IMPLEMENTS: ----------------------------------------------------------------------------

        public override void OnUpdate(TShotType shotType)
        {
            base.OnUpdate(shotType);
            
            Vector3 target = this.GetTargetPosition(shotType);
            Vector3 source = this.GetAnchorPosition(shotType);
            Vector3 direction = target - source;
            
            shotType.Position = source;
            shotType.Rotation = Quaternion.LookRotation(direction);
        }
        
        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        public Transform GetTargetTransform(IShotType shotType)
        {
            GameObject target = this.m_Target.Get(shotType.ShotCamera);
            return target != null ? target.transform : null;
        }

        public Vector3 GetTargetPosition(IShotType shotType)
        {
            Transform target = this.GetTargetTransform(shotType);
            Vector3 offset = target != null
                ? this.m_Offset.Get(target)
                : shotType.ShotCamera.transform.TransformPoint(Vector3.forward);
            
            return target != null ? target.position + offset : default;
        }
        
        private Vector3 GetAnchorPosition(TShotType shotType)
        {
            Transform target = this.GetTargetTransform(shotType);
            if (target == null) return shotType.Position;
        
            Vector3 distance = this.m_Distance.Get(shotType.Args);
            return target.transform.position + distance;
        }

        // GIZMOS: --------------------------------------------------------------------------------

        public override void OnDrawGizmosSelected(TShotType shotType, Transform transform)
        {
            base.OnDrawGizmosSelected(shotType, transform);
            this.DoDrawGizmos(shotType, GIZMOS_COLOR_ACTIVE);
        }

        // PRIVATE METHODS: -----------------------------------------------------------------------

        private void DoDrawGizmos(TShotType shotType, Color color)
        {
            if (!Application.isPlaying) return;
            
            Gizmos.color = color;

            Vector3 target = this.GetTargetPosition(shotType);
            Vector3 source = this.GetAnchorPosition(shotType);

            Gizmos.DrawLine(source, target);
        }
    }
}