using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Cameras
{
    [Image(typeof(IconShotAnchor), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public abstract class TInstructionShotPeek : TInstructionShot
    {
        protected override int SystemID => ShotSystemPeek.ID;
    }
}