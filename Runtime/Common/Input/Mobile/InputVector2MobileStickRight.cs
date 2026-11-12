using System;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Right Touch Stick")]
    [Category("Mobile/Right Touch Stick")]
    [Description("An on-screen joystick on the right side of the screen, commonly used to rotate the camera on mobile devices")]

    [Image(typeof(IconTouchstick), ColorTheme.Type.Yellow, typeof(BadgeArrowRight))]
    [Keywords("Virtual", "Joystick", "Touchstick", "Direction", "Mobile")]

    [Serializable]
    public class InputVector2MobileStickRight : TInputVector2MobileStick
    {
        protected override ITouchStick CreateTouchStick() => TouchStickRight.Create();

        public override string ToString() => "Right Touch Stick";
    }
}
