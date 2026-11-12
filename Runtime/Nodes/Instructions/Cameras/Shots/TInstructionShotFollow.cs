using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotFollow), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotFollow : TInstructionShot
    {
        protected override int SystemID => ShotSystemFollow.ID;
    }
}