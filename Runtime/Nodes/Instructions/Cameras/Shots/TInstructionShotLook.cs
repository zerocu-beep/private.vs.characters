using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotFixed), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotLook : TInstructionShot
    {
        protected override int SystemID => ShotSystemLook.ID;
    }
}