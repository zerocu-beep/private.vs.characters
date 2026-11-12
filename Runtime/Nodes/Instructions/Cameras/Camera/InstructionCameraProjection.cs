using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Projection")]
    [Description("Changes the camera projection to either Perspective or Orthographic")]

    [Category("Cameras/Properties/Change Projection")]

    [Parameter("Camera", "The camera component whose property changes")]
    [Parameter("Projection", "Whether to change to Orthographic or Perspective mode")]

    [Keywords("Cameras", "Orthographic", "Perspective", "3D", "2D")]
    [Image(typeof(IconCamera), ColorTheme.Type.Blue)]
    
    [Serializable]
    public class InstructionCameraProjection : Instruction
    {
        private enum Projection
        {
            Orthographic,
            Perspective
        }
        
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private Projection m_Projection = Projection.Perspective;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Change Projection to {this.m_Projection}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;

            bool isOrthographic = this.m_Projection == Projection.Orthographic;
            camera.Viewport.SetProjection(isOrthographic);
            
            return Done;
        }
    }
}