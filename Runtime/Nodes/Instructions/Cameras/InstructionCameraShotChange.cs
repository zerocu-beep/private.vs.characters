using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change to Shot")]
    [Description("Changes the active Shot for a particular camera")]

    [Category("Cameras/Change to Shot")]

    [Parameter("Camera", "The target camera component")]
    [Parameter("Shot", "The camera Shot that becomes active")]
    [Parameter("Duration", "How long it takes to transition to the new Shot, in seconds")]
    [Parameter("Wait To Complete", "If the instruction waits till the transition is complete")]

    [Keywords("Cameras", "Render", "Switch", "Move")]
    [Image(typeof(IconCameraShot), ColorTheme.Type.Blue)]
    
    [Serializable]
    public class InstructionCameraShotChange : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space]
        [SerializeField] private GetGameObject m_Shot = TypeGameObjectShot.Create;

        [Space] 
        [SerializeField] private Easing.Type m_Easing = Easing.Type.QuadInOut;
        
        [SerializeField] private float m_Duration = 0f;

        [ConditionShow(nameof(m_Duration))]
        [SerializeField] private bool m_WaitToComplete = false;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => string.Format(
            "Change Shot to {0} {1}",
            this.m_Shot,
            this.m_Duration <= 0f ? string.Empty : $"in {this.m_Duration}s");

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override async Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            ShotCamera shot = this.m_Shot.Get<ShotCamera>(args);
            
            if (camera == null) return;
            if (shot == null) return;
            
            camera.Transition.ChangeToShot(shot, this.m_Duration, this.m_Easing);

            if (!this.m_WaitToComplete) return;
            await this.WaitForSeconds(this.m_Duration);
        }
    }
}