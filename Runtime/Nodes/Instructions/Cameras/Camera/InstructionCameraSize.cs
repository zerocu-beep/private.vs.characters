using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;


    [Title("Change Orthographic Size")]
    [Description("Changes the camera's orthographic size")]

    [Category("Cameras/Properties/Change Orthographic Size")]

    [Parameter("Camera", "The camera component whose property changes")]
    [Parameter("Size", "The new size of the orthographic view")]
    [Parameter("Duration", "The time in seconds, it takes for the camera to complete the change")]
    [Parameter("Easing", "The easing function used to transition")]

    [Keywords("Cameras", "Orthographic", "Size", "2D")]
    [Image(typeof(IconCamera), ColorTheme.Type.Blue)]
    
    [Serializable]
    public class InstructionCameraSize : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Camera = new GetGameObject(new TypeGameObjectCameraMain());
        
        [SerializeField] private GetNumber m_Size = new GetNumber(5f);

        [SerializeField] private GetNumber m_Duration = new GetNumber(1f);
        [SerializeField] private Easing.Type m_Easing = Easing.Type.QuadInOut;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"Change Orthographic Size to {this.m_Size}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            TCamera camera = this.m_Camera.Get<TCamera>(args);
            if (camera == null) return Done;

            float size = (float) this.m_Size.Get(args);
            float duration = (float) this.m_Duration.Get(args);

            camera.Viewport.SetOrthographicSize(size, duration, this.m_Easing);
            return Done;
        }
    }
}