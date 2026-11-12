using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotFirstPerson), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotHeadLeaning : TInstructionShot
    {
        protected override int SystemID => ShotSystemHeadLeaning.ID;
    }
}