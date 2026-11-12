using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotLockOn), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotLockOn : TInstructionShot
    {
        protected override int SystemID => ShotSystemLockOn.ID;
    }
}