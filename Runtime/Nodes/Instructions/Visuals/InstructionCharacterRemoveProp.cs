using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Remove Prop")]
    [Description("Removes a prefab or instance Prop (if any) from a Character")]

    [Category("Characters/Visuals/Remove Prop")]

    [Parameter("Character", "The character target")]
    [Parameter("Type", "Whether to remove the prop form a prefab or as its instance")]
    [Parameter("Prop", "The prefab or instance object prop that is removed from the character")]

    [Keywords("Characters", "Detach", "Let", "Sheathe", "Put", "Holster", "Object")]
    [Image(typeof(IconTennis), ColorTheme.Type.TextLight, typeof(BadgeMinus))]

    [Serializable]
    public class InstructionCharacterRemoveProp : Instruction
    {
        private enum Type
        {
            Prefab,
            Instance
        }
        
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField] private Type m_Type = Type.Prefab;
        [SerializeField] private GetGameObject m_Prop = new GetGameObject();

        protected override string GetTitle(GameObject source) => $"Remove {this.m_Type} {this.m_Prop} from {this.m_Character}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject prop = this.m_Prop.Get(args);
            if (prop == null) return Done;

            switch (this.m_Type)
            {
                case Type.Prefab:
                    character.Props.RemovePrefab(prop);
                    break;
                
                case Type.Instance:
                    character.Props.RemoveInstance(prop);
                    break;
                
                default: throw new ArgumentOutOfRangeException();
            }
            
            return Done;
        }
    }
}