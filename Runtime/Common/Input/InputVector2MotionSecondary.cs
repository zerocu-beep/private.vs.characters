using System;
using UnityEngine.InputSystem;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Secondary Motion")]
    [Category("Usage/Secondary Motion")]
    [Description("Secondary motion commonly used to orbit the camera: Mouse movement and Right Stick on Gamepads")]
    [Image(typeof(IconGamepadCross), ColorTheme.Type.Green)]
    [Keywords("Orbit", "Look", "Camera", "Mouse", "Joystick")]
    [Serializable]
    public class InputVector2MotionSecondary : InputVector2InputActionBase
    {
        protected override UnityEngine.InputSystem.InputAction CreateInputAction
        {
            get
            {
                UnityEngine.InputSystem.InputAction inputAction = new UnityEngine.InputSystem.InputAction(
                    "Secondary Motion",
                    InputActionType.Value
                );

                inputAction.AddBinding("<Mouse>/delta", processors: "invertVector2(invertX=false,invertY=true)");
                inputAction.AddBinding("<Gamepad>/rightStick", processors: "invertVector2(invertX=false,invertY=true)");

                return inputAction;
            }
        }

        public override string ToString() => "Secondary Motion";
    }
}
