using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Aim")]
    [Category("Cameras/Shots/Third Person/Change Aim")]
    [Description("Changes the aim settings of a Shot keeping the focus point")]

    [Parameter("Shoulder", "The horizontal distance from the pivot")]
    [Parameter("Lift", "The amount of upwards distance from the pivot")]
    [Parameter("Radius", "The maximum amount of distance from the pivot allowed")]
    
    [Parameter("Keep Center", "If true the point at the center of the screen is kept when aiming")]
    [Parameter("Layer Mask", "The layer mask for the hit-scan to check the focus point")]
    
    [Serializable]
    public class InstructionShotThirdPersonChangeAim : TInstructionShotThirdPerson
    {
        private const float BIG_F_NUMBER = 999f;
        
        private static readonly RaycastHit[] HITS = new RaycastHit[32];
        
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField, FormerlySerializedAs("m_Shoulder")] private GetNumber m_OffsetShoulder = new GetNumber(0.25f);
        [SerializeField, FormerlySerializedAs("m_Lift")] private GetNumber m_OffsetLift = new GetNumber(0.5f);
        [SerializeField, FormerlySerializedAs("m_Radius")] private GetNumber m_OffsetRadius = new GetNumber(5f);
        
        [SerializeField] private EnablerLayerMask m_KeepCenter = new EnablerLayerMask(true, Physics.DefaultRaycastLayers);
        [SerializeField] private GetNumber m_Duration = new GetNumber(0.25f);

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Change {this.m_Shot}[Third Person] Aim";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemThirdPerson shotSystem = this.GetShotSystem<ShotSystemThirdPerson>(args);
            if (shotSystem == null) return Done;
            
            Transform camera = ShortcutMainCamera.Transform;
            if (camera == null) return Done;

            float duration = (float) this.m_Duration.Get(args);
            
            if (this.m_KeepCenter.IsEnabled == false)
            {
                shotSystem.Aim(
                    (float) this.m_OffsetShoulder.Get(args),
                    (float) this.m_OffsetLift.Get(args),
                    (float) this.m_OffsetRadius.Get(args),
                    Math.Max(duration, 0f)
                );
                
                return Done;
            }

            Transform pivot = shotSystem.Pivot != null ? shotSystem.Pivot.transform : null;
            if (pivot == null) return Done;
            
            Vector3 direction = camera.TransformDirection(Vector3.forward);
            int numHits = Physics.RaycastNonAlloc(
                camera.position,
                direction,
                HITS,
                BIG_F_NUMBER,
                this.m_KeepCenter.Value,
                QueryTriggerInteraction.Ignore
            );

            bool hasHit = false;
            float hitDistance = -1f;
            Vector3 hitPoint = Vector3.zero;

            for (int i = 0; i < numHits; ++i)
            {
                RaycastHit hit = HITS[i];
                if (hit.transform.IsChildOf(pivot)) continue;
                if (hitDistance >= 0f && hit.distance > hitDistance) continue;
                
                hasHit = true;
                hitPoint = hit.point;
                hitDistance = hit.distance;
            }
            
            Vector3 focusPoint = hasHit ? hitPoint : direction * BIG_F_NUMBER;
            
            shotSystem.Aim(
                (float) this.m_OffsetShoulder.Get(args),
                (float) this.m_OffsetLift.Get(args),
                (float) this.m_OffsetRadius.Get(args),
                focusPoint,
                Math.Max(duration, 0f)
            );
            
            return Done;
        }
    }
}