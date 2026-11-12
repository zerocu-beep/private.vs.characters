using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Left Touch Stick")]
    [Category("Mobile/Left Touch Stick")]
    [Description("An on-screen joystick on the left side of the screen, commonly used to move the Player on mobile devices")]

    [Image(typeof(IconTouchstick), ColorTheme.Type.Yellow, typeof(BadgeArrowLeft))]
    [Keywords("Virtual", "Joystick", "Touchstick", "Direction", "Mobile")]

    [Serializable]
    public class InputVector2MobileStickLeft : TInputVector2MobileStick
    {
        protected override ITouchStick CreateTouchStick() => TouchStickLeft.Create();

        public override string ToString() => "Left Touch Stick";
    }
}
