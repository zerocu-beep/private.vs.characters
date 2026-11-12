using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Stop Camera Shake Bursts")]
    [Description("Stops any ongoing camera Burst Shake effects")]

    [Category("Cameras/Shakes/Stop Shake Camera Bursts")]

    [Parameter("Camera", "The camera target that stops all its active Burst Shake effects")]
    [Parameter("Delay", "Amount of time before all Burst Shake effects start blending out")]
    [Parameter("Transition", "Amount of time it takes to blend out all Burst Shake effects")]

    [Keywords("Cameras", "Animation", "Animate", "Shake", "Impact", "Play")]
    [Image(typeof(IconCameraShake), ColorTheme.Type.Yellow, typeof(BadgeCross))]
    
    [Serializable]
    public class InstructionCameraStopBursts : Instruction
    {
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private float m_Delay = 0f;
        [SerializeField] private float m_Transition = 0.5f;

        protected override string GetTitle(GameObject source) => $"Stop burst shakes on {this.m_Camera}";

        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;
            
            camera.StopBurstShakes(
                this.m_Delay, 
                this.m_Transition
            );
            
            return Done;
        }
    }
}