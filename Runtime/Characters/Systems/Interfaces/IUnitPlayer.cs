using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Player")]
    
    public interface IUnitPlayer : IUnitCommon
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        bool IsControllable { get; set; }

        Vector3 LocalInputDirection { get; }
        Vector3 InputDirection { get; }
    }
}