using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Hotspots
{
    [Title("Activate Hotspots")]
    [Description("Determines whether Hotspots can be activated or are inactive by type")]

    [Category("Visual Scripting/Activate Hotspots")]

    [Parameter("Type", "The type of Hotspots to activate or deactivate")]
    [Parameter("Active", "Determines if Hotspots can run or are inactive")]
    
    [Keywords("Execute", "Enable", "Disable", "Show", "Hide", "Deactivate")]
    [Image(typeof(IconHotspot), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class InstructionLogicHotspotsActive : Instruction
    {
        [Flags]
        private enum HotspotType
        {
            Radial       = 1 << 0, // 0b001
            Interactive  = 1 << 1, // 0b010
            AlwaysActive = 1 << 2  // 0b100
        }
        
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private HotspotType m_HotspotsType = HotspotType.Interactive; 
        [SerializeField] private GetBool m_Active = new GetBool(true);
        
        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source)
        {
                string types = TextUtils.Humanize(this.m_HotspotsType);
                return $"{types} Hotspots Active = {this.m_Active}";
        }

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            bool active = this.m_Active.Get(args);
            
            bool radial = ((int) this.m_HotspotsType & (int) HotspotType.Radial) != 0;
            bool interactive = ((int) this.m_HotspotsType & (int) HotspotType.Interactive) != 0;
            bool always = ((int) this.m_HotspotsType & (int) HotspotType.AlwaysActive) != 0;
            
            if (radial) Hotspot.ActiveInRadius = active;
            if (interactive) Hotspot.ActiveInteractive = active;
            if (always) Hotspot.ActiveAlways = active;
            
            return Done;
        }
    }
}