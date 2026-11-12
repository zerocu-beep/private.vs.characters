using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    using VisualScript.Runtime.Characters;

    [Title("Is Shot Active")]
    [Description("Returns true if the Camera Shot is assigned to the Main Camera")]

    [Category("Cameras/Is Shot Active")]
    
    [Parameter("Shot", "The camera shot")]

    [Keywords("Camera", "Enabled", "Assigned", "Running")]
    [Image(typeof(IconCameraShot), ColorTheme.Type.Green)]
    
    [Serializable]
    public class ConditionCameraShotActive : Condition
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetGameObject m_Shot = TypeGameObjectShot.Create;

        // PROPERTIES: ----------------------------------------------------------------------------
        
        protected override string GetTitle(GameObject source) => $"is {this.m_Shot} Active";
        
        // RUN METHOD: ----------------------------------------------------------------------------

        protected override bool Run(Args args)
        {
            ShotCamera shot = this.m_Shot.Get<ShotCamera>(args);
            if (shot == null) return false;

            MainCamera mainCamera = ShortcutMainCamera.Get<MainCamera>();
            if (mainCamera == null) return false;

            return mainCamera.Transition.CurrentShotCamera == shot;
        }
    }
}
