using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotFirstPerson), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotNoise : TInstructionShot
    {
        protected override int SystemID => ShotSystemNoise.ID;
    }
}