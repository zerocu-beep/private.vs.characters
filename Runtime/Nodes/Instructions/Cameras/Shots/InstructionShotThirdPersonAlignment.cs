using System;
using UnityEngine;

namespace VisualScript.Runtime.Cameras
{
    [Title("Change Alignment")]
    [Category("Cameras/Shots/Third Person/Change Alignment")]
    [Description("Changes whether and how the Shot aligns behind the targeted object")]

    [Parameter("Align with Target", "If the Shot should move behind the target after some idle time")]
    [Parameter("Delay", "If the Shot should move behind the target after some idle time")]
    [Parameter("Smooth Time", "The speed at which ")]
    
    
    [Serializable]
    public class InstructionShotThirdPersonAlignment : TInstructionShotThirdPerson
    {
        // MEMBERS: -------------------------------------------------------------------------------
        
        [SerializeField] private bool m_AutoAlign = true;
        [SerializeField] private float m_Delay = 3f;
        [SerializeField] private float m_SmoothTime = 5f;

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => string.Format(
            "Set {0}[Third Person] Align = {1}", 
            this.m_Shot,
            this.m_AutoAlign ? "Yes" : "No"
        );

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            ShotSystemThirdPerson shotSystem = this.GetShotSystem<ShotSystemThirdPerson>(args);
            if (shotSystem == null) return Done;
            
            shotSystem.Alignment.AutoAlign = this.m_AutoAlign;
            shotSystem.Alignment.Delay = this.m_Delay;
            shotSystem.Alignment.SmoothTime = this.m_SmoothTime;
            
            return Done;
        }
    }
}