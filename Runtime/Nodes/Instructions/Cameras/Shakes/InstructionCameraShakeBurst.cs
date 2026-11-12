using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Shake Camera Burst")]
    [Description("Shakes the camera for an amount of time")]

    [Category("Cameras/Shakes/Shake Camera Burst")]

    [Parameter("Camera", "The camera that receives the burst shake effect")]
    [Parameter("Delay", "Amount of time in seconds before the shake effect starts")]
    [Parameter("Duration", "Amount of time the shake effect stays active")]
    
    [Parameter("Shake Position", "If the shake affects the position of the camera")]
    [Parameter("Shake Rotation", "If the shake affects the rotation of the camera")]
    [Parameter("Magnitude", "The maximum amount the camera displaces from its position")]
    [Parameter("Roughness", "Frequency or how violently the camera shakes")]
    
    [Parameter("Transform", "[Optional] Defines the origin of the shake")]
    [Parameter("Radius", "[Optional] Distance from the origin that the shake starts to fall-off")]

    [Keywords("Cameras", "Animation", "Animate", "Shake", "Impact", "Play")]
    [Image(typeof(IconCameraShake), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionCameraShakeBurst : Instruction
    {
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private float m_Delay = 0f;
        [SerializeField] private float m_Duration = 0.5f;
        
        [Space] 
        [SerializeField] private ShakeEffect m_ShakeEffect = ShakeEffect.Create;

        protected override string GetTitle(GameObject source) => 
            $"Burst shake {this.m_Camera} for {this.m_Duration} seconds";

        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;
            
            camera.AddBurstShake(
                this.m_Delay, 
                this.m_Duration, 
                this.m_ShakeEffect
            );
            
            return Done;
        }
    }
}