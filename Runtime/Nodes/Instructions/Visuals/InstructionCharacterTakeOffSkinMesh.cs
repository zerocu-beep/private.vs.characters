using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Take off Skin Mesh")]
    [Description("Removes an instance of a Skin Mesh from a Character")]

    [Category("Characters/Visuals/Take off Skin Mesh")]
    
    [Parameter("Prefab", "Game Object reference with a Skin Mesh Renderer that is removed")]
    [Parameter("From Character", "Target Character that uses its armature to wear the skin mesh")]
    
    [Image(typeof(IconSkinMesh), ColorTheme.Type.TextLight, typeof(BadgeArrowRight))]
    
    [Keywords("Renderer", "Game Object", "Armature")]
    [Serializable]
    public class InstructionCharacterTakeOffSkinMesh : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Prefab = new GetGameObject(new TypeGameObjectInstance());
        
        [SerializeField] private GetGameObject m_FromCharacter = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Take {this.m_Prefab} off {this.m_FromCharacter}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_FromCharacter.Get<Character>(args);
            GameObject prefab = this.m_Prefab.Get(args);

            if (character == null) return Done;
            if (prefab == null) return Done;

            character.Props.RemoveSkinMesh(prefab);
            return Done;
        }
    }
}