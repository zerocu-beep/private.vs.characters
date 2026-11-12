using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotTrack), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotTrack : TInstructionShot
    {
        protected override int SystemID => ShotSystemTrack.ID;
    }
}