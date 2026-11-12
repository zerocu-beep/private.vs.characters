using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotFirstPerson), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotHeadBobbing : TInstructionShot
    {
        protected override int SystemID => ShotSystemHeadBobbing.ID;
    }
}