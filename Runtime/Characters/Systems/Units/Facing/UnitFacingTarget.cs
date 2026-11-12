using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Look at Target")]
    [Image(typeof(IconCubeSolid), ColorTheme.Type.Blue)]
    
    [Category("Targets/Look at Target")]
    [Description("Rotates the Character towards a specific game object target")]
    
    [Serializable]
    public class UnitFacingTarget : TUnitFacing
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------
        
        [SerializeField] private GetGameObject m_Target = new GetGameObject(new TypeGameObjectPlayer());
        
        // MEMBERS: -------------------------------------------------------------------------------
        
        [NonSerialized] private Args m_Args;
        
        // PROPERTIES: ----------------------------------------------------------------------------
        
        public override Axonometry Axonometry
        {
            get => null;
            set => _ = value;
        }
        
        // METHODS: -------------------------------------------------------------------------------

        protected override Vector3 GetDefaultDirection()
        {
            if (this.m_Args == null) this.m_Args = Args.Get(this.Character, this.Character);

            GameObject gameObject = this.m_Target.Get(this.m_Args);

            Vector3 driverDirection = Vector3.Scale(
                gameObject != null 
                    ? gameObject.transform.position - this.Transform.position 
                    : this.Character.Driver.WorldMoveDirection,
                Vector3Plane.NormalUp
            );

            return this.DecideDirection(driverDirection);
        }
        
        // STRING: --------------------------------------------------------------------------------

        public override string ToString() => "Look at Target";
    }
}