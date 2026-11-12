using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    [Title("Tank")]
    [Image(typeof(IconTank), ColorTheme.Type.Green)]
    
    [Category("Direction/Tank")]
    [Description("Rotates the Character around itself based on the input")]

    [Serializable]
    public class UnitFacingTank : TUnitFacing
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private InputVector2 m_InputMove;
        [SerializeField] private Axonometry m_Axonometry = new Axonometry();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public override Type ForcePlayer => typeof(UnitPlayerTank);
        
        public override Axonometry Axonometry
        {
            get => this.m_Axonometry;
            set => this.m_Axonometry = value;
        }

        // INITIALIZERS: --------------------------------------------------------------------------

        public UnitFacingTank()
        {
            this.m_InputMove = new InputVector2(new InputVector2MotionPrimary());
        }

        // OVERRIDERS: ----------------------------------------------------------------------------

        public override void OnStartup(Character character)
        {
            base.OnStartup(character);
            this.m_InputMove.Awake();
            this.m_InputMove.Enable();
        }
        
        public override void OnDispose(Character character)
        {
            base.OnDispose(character);
            this.m_InputMove.Disable();
            this.m_InputMove.Destroy();
        }

        protected override Vector3 GetDefaultDirection()
        {

            if (!this.Character.IsPlayer || !this.Character.Player.IsControllable)
            {
                Vector3 noDirection = this.DecideDirection(Vector3.zero);
                return this.m_Axonometry?.ProcessRotation(this, noDirection) ?? noDirection;
            }

            Vector3 inputMovement = this.m_InputMove.Read();
            Vector3 direction = Vector3.Scale(
                this.Transform.TransformDirection(inputMovement),
                Vector3Plane.NormalUp
            );

            Vector3 result = this.DecideDirection(direction);
            return this.m_Axonometry?.ProcessRotation(this, result) ?? result;
        }
        
        protected virtual Vector3 GetMoveDirection(Vector3 input)
        {
            Vector3 direction = new Vector3(input.x, 0f, 0f);
            Vector3 moveDirection = this.Transform.TransformDirection(direction);
        
            moveDirection.Scale(Vector3Plane.NormalUp);
            moveDirection.Normalize();
        
            return moveDirection * direction.magnitude;
        }
        
        // STRING: --------------------------------------------------------------------------------

        public override string ToString() => "Tank";
    }
}