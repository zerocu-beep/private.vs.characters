using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Teleport")]
    [Description("Instantaneously moves a Character from its current position to a new one")]

    [Category("Characters/Navigation/Teleport")]
    
    [Parameter("Location", "The position and/or rotation where the Character is teleported")]

    [Keywords("Change", "Position", "Location", "Respawn", "Spawn")]
    [Image(typeof(IconCharacter), ColorTheme.Type.Blue)]

    [Serializable]
    public class InstructionCharacterNavigationTeleport : TInstructionCharacterNavigation
    {
        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private GetLocation m_Location = new GetLocation(new TypeLocationNavigationMarker());

        // PROPERTIES: ----------------------------------------------------------------------------

        protected override string GetTitle(GameObject source) => $"Teleport {this.m_Character} to {this.m_Location}";

        // RUN METHOD: ----------------------------------------------------------------------------
        
        protected override Awaitable Run(Args args)
        {
            Character character = this.m_Character.Get<Character>(args);
            if (character == null) return Done;

            Location location = this.m_Location.Get(args);
            
            Vector3 position = location.GetPosition(character.gameObject);
            Quaternion rotation = location.GetRotation(character.gameObject);

            if (location.HasPosition(character.gameObject)) character.Driver.SetPosition(position, true);
            if (location.HasRotation(character.gameObject)) character.Driver.SetRotation(rotation);
            
            return Done;
        }
    }
}