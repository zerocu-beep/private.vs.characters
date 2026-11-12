using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Stop Camera Sustain Shake")]
    [Description("Stops a Sustain Shake camera effect in a particular layer layer")]

    [Category("Cameras/Shakes/Stop Camera Sustain Shake")]
    
    [Parameter("Camera", "The camera target that stops a Sustain Shake effect")]
    [Parameter("Layer", "The camera layer from which the Sustain Shake effect is removed")]
    [Parameter("Delay", "Amount of time before the Sustain Shake effect starts blending out")]
    [Parameter("Transition", "Amount of time it takes to blend out the Sustain Shake effect")]

    [Keywords("Cameras", "Animation", "Animate", "Shake", "Wave", "Play")]
    [Image(typeof(IconCameraShake), ColorTheme.Type.Green, typeof(BadgeCross))]
    
    [Serializable]
    public class InstructionCameraStopSustain : Instruction
    {
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private int m_Layer = 0;
        [SerializeField] private float m_Delay = 0f;
        [SerializeField] private float m_Transition = 0.5f;

        protected override string GetTitle(GameObject source) => 
            $"Stop {this.m_Camera} sustain shake on layer {this.m_Layer}";

        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;
            
            camera.RemoveSustainShake(
                this.m_Layer,
                this.m_Delay, 
                this.m_Transition
            );
            
            return Done;
        }
    }
}