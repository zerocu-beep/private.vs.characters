using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Culling Mask")]
    [Description("Changes the camera culling mask")]

    [Category("Cameras/Properties/Change Culling Mask")]

    [Parameter("Camera", "The camera component whose property changes")]
    [Parameter("Culling Mask", "The mask the camera uses to discern which objects to render")]

    [Keywords("Cameras", "Render")]
    [Image(typeof(IconCamera), ColorTheme.Type.Blue)]
    
    [Serializable]
    public class InstructionCameraCullingMask : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());

        [Space] 
        [SerializeField] private LayerMask m_CullingMask = Physics.DefaultRaycastLayers;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => "Change Culling Mask";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;

            camera.Get<Camera>().cullingMask = this.m_CullingMask;
            return Done;
        }
    }
}