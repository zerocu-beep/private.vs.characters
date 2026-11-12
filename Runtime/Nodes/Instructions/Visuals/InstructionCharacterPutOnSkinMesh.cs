using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Put on Skin Mesh")]
    [Description("Creates a new instance of a skin mesh renderer and puts it on a Character")]

    [Category("Characters/Visuals/Put on Skin Mesh")]
    
    [Parameter("Prefab", "Game Object reference with a Skin Mesh Renderer that is instantiated")]
    [Parameter("On Character", "Target Character that uses its armature to wear the skin mesh")]
    
    [Image(typeof(IconSkinMesh), ColorTheme.Type.Yellow, typeof(BadgeArrowLeft))]
    
    [Keywords("Renderer", "New", "Game Object", "Armature")]
    [Serializable]
    public class InstructionCharacterPutOnSkinMesh : Instruction
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] 
        private GetGameObject m_Prefab = new GetGameObject(new TypeGameObjectInstance());
        
        [SerializeField] private GetGameObject m_OnCharacter = new GetGameObject(new TypeGameObjectPlayer());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Put {this.m_Prefab} on {this.m_OnCharacter}";

        // RUN METHOD: ----------------------------------------------------------------------------

        protected override Awaitable Run(Args args)
        {
            Character character = this.m_OnCharacter.Get<Character>(args);
            GameObject prefab = this.m_Prefab.Get(args);

            if (character == null) return Done;
            if (prefab == null) return Done;

            character.Props.AttachSkinMesh(prefab);
            return Done;
        }
    }
}