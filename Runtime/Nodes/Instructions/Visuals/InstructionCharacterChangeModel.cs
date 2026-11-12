using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Change Model")]
    [Description("Changes the Character current model")]

    [Category("Characters/Visuals/Change Model")]

    [Parameter("Character", "The character target")]
    [Parameter("Model", "The prefab object that replaces the current Character model")]
    [Parameter("Skeleton", "Optional parameter that replaces the configuration of volumes")]
    [Parameter("Footstep Sounds", "Optional parameter that replaces the current Footstep sounds")]
    [Parameter("Offset", "A local offset from the center of the Character")]

    [Keywords("Characters", "Model")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Yellow)]

    [Serializable]
    public class InstructionCharacterChangeModel : Instruction
    {
        [SerializeField] private GetGameObject m_Character = new GetGameObject(new TypeGameObjectPlayer());
        
        [Space]
        [SerializeField] private GetGameObject m_Model = new GetGameObject();
        
        [SerializeField] private MaterialSoundsAsset m_MaterialSounds;
        [SerializeField] private Vector3 m_Offset = Vector3.zero;

        protected override string GetTitle(GameObject source) => $"Change Model on {this.m_Character} to {this.m_Model}";

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            GameObject model = this.m_Model.Get(args);
            if (model == null) return Done;

            character.ChangeModel(model, new Character.ChangeOptions
            {
                materials = this.m_MaterialSounds,
                offset = this.m_Offset
            });
            
            return Done;
        }
    }
}