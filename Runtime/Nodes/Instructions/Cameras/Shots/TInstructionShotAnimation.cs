using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotAnimation), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotAnimation : TInstructionShot
    {
        protected override int SystemID => ShotSystemAnimation.ID;
    }
}