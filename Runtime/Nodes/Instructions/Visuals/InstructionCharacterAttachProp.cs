using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Attach Prop")]
    [Description("Attaches a prefab or instance Prop onto a Character's bone")]

    [Category("Characters/Visuals/Attach Prop")]

    [Parameter("Character", "The character target")]
    [Parameter("Type", "Whether to attach the prop as a prefab or instance")]
    [Parameter("Prop", "The prefab or instance object that is attached to the character")]
    [Parameter("Bone", "Which bone the prop is attached to")]
    [Parameter("Position", "Local offset from which the prop is distanced from the bone")]
    [Parameter("Rotation", "Local offset from which the prop is rotated from the bone")]

    [Keywords("Characters", "Add", "Grab", "Draw", "Pull", "Take", "Object")]
    [Image(typeof(IconTennis), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterAttachProp : Instruction
    {
        private enum Type
        {
            Prefab,
            Instance
        }

        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private Type m_Type = Type.Prefab;
        [SerializeField] private GetGameObject m_Prop = new GetGameObject();

        [SerializeField] private HandleField m_Handle = new HandleField();

        protected override string GetTitle(GameObject source) => $"Attach {this.m_Type} {this.m_Prop} on {this.m_Character} {this.m_Handle}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject prop = this.m_Prop.Get(args);
            if (prop == null) return Done;

            Args handleArgs = Args.Get(character.gameObject, character.gameObject);
            HandleResult handle = this.m_Handle.Get(handleArgs);
            
            switch (this.m_Type)
            {
                case Type.Prefab:
                    character.Props.AttachPrefab(
                        handle.Bone, prop,
                        handle.LocalPosition, handle.LocalRotation
                    );
                    break;
                
                case Type.Instance:
                    character.Props.AttachInstance(
                        handle.Bone, prop,
                        handle.LocalPosition, handle.LocalRotation
                    );
                    break;
                
                default: throw new ArgumentOutOfRangeException();
            }

            return Done;
        }
    }
}