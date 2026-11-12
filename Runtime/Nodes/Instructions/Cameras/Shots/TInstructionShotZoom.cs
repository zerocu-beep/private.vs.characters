using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotThirdPerson), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotZoom : TInstructionShot
    {
        protected override int SystemID => ShotSystemZoom.ID;
    }
}