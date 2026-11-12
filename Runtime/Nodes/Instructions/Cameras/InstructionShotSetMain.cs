using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconCameraShot), ColorTheme.Type.Yellow)]
    
    [Title("Set Main Shot")]
    [Category("Cameras/Set Main Shot")]
    [Description("Assigns a Camera Shot as the new Main Shot")]

    [Parameter("Shot", "The new main Camera Shot")]

    [Serializable]
    public class InstructionShotSetMain : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] protected GetGameObject m_Shot = TypeGameObjectShot.Create;

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Set {this.m_Shot} as Main Shot";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotCamera shotCamera = this.m_Shot.Get<ShotCamera>(args);
            ShortcutMainShot.Change(shotCamera);
            
            return Done;
        }
    }
}