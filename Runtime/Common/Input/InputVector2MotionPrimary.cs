using System;
using UnityEngine.InputSystem;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Primary Motion")]
    [Category("Usage/Primary Motion")]
    [Description("Primary motion commonly used to move the main character: WASD and Arrow keys on Keyboard and Left Stick on Gamepads")]
    [Image(typeof(IconGamepadCross), ColorTheme.Type.Yellow)]
    [Keywords("Move", "Joystick", "WASD", "Arrows")]
    [Serializable]
    public class InputVector2MotionPrimary : InputVector2InputActionBase
    {
        protected override UnityEngine.InputSystem.InputAction CreateInputAction
        {
            get
            {
                UnityEngine.InputSystem.InputAction inputAction = new UnityEngine.InputSystem.InputAction(
                    "Primary Motion",
                    InputActionType.Value
                );

                inputAction.AddBinding("<Gamepad>/leftStick");
                inputAction.AddCompositeBinding("2DVector")
                    .With("Up", "<Keyboard>/w")
                    .With("Down", "<Keyboard>/s")
                    .With("Left", "<Keyboard>/a")
                    .With("Right", "<Keyboard>/d");
                inputAction.AddCompositeBinding("2DVector")
                    .With("Up", "<Keyboard>/upArrow")
                    .With("Down", "<Keyboard>/downArrow")
                    .With("Left", "<Keyboard>/leftArrow")
                    .With("Right", "<Keyboard>/rightArrow");

                return inputAction;
            }
        }

        public override string ToString() => "Primary Motion";
    }
}
