using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public class Weapon
    {
        // PROPERTIES: ----------------------------------------------------------------------------

        public int Id => this.Asset?.Id.GetHashCode() ?? IdString.Empty.GetHashCode();

        [field: NonSerialized] public IWeapon Asset { get; }
        [field: NonSerialized] public GameObject Instance { get; }

        // CONSTRUCTOR: ---------------------------------------------------------------------------

        public Weapon(IWeapon weapon, GameObject instance)
        {
            this.Asset = weapon;
            this.Instance = instance;
        }
    }
}