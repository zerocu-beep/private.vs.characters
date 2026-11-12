using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Smooth Time")]
    [Description("Changes the camera Smooth Time")]

    [Category("Cameras/Properties/Change Smooth Time")]

    [Parameter("Camera", "The camera component whose property changes")]
    [Parameter("Smooth Position", "The new smooth value for translation")]
    [Parameter("Smooth Rotation", "The new smooth value for rotation")]

    [Keywords("Cameras")]
    [Image(typeof(IconCamera), ColorTheme.Type.Blue)]
    
    [Serializable]
    public class InstructionCameraSmoothTime : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());
        
        [SerializeField] private GetNumber m_SmoothPosition = new GetNumber(0.1f);
        [SerializeField] private GetNumber m_SmoothRotation = new GetNumber(0.1f);

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Change Smooth of {this.m_Camera}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;

            camera.Transition.SmoothTimePosition = (float) this.m_SmoothPosition.Get(args);
            camera.Transition.SmoothTimeRotation = (float) this.m_SmoothRotation.Get(args);
            
            return Done;
        }
    }
}