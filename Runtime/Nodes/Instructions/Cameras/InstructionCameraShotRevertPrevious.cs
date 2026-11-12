using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Revert to Previous Shot")]
    [Description("Reverts the active Shot of a particular camera to the previous one")]

    [Category("Cameras/Revert to previous Shot")]

    [Parameter("Camera", "The target camera component")]
    [Parameter("Duration", "How long it takes to transition to the new Shot, in seconds")]

    [Keywords("Cameras", "Render", "Switch", "Move")]
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow, typeof(BadgeArrowLeft))]
    
    [Serializable]
    public class InstructionCameraShotRevertPrevious : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private float m_Duration = 0f;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Revert to {this.m_Camera}'s previous Shot";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);

            if (camera == null) return Done;
            camera.Transition.ChangeToPreviousShot(this.m_Duration);
            
            return Done;
        }
    }
}