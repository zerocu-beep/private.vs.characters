using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Towards Direction")]
    [Category("Math/Towards Direction")]
    
    [Image(typeof(IconVector3), ColorTheme.Type.Yellow, typeof(BadgePlus))]
    [Description("Rotation from an Identity rotation towards a direction vector")]
    
    [Get]
    
    [Serializable]
    public class TypeQuaternionTowardsDirection : TypeQuaternion
    {
        [SerializeField]
        protected GetVector3 m_Direction = new GetVector3(Vector3.zero);
        
        public TypeQuaternionTowardsDirection()
        { }
        
        public TypeQuaternionTowardsDirection(Vector3 direction) : this()
        {
            this.m_Direction = new GetVector3(direction);
        }

        public override Quaternion Get(Args args)
        {
            Vector3 direction = this.m_Direction.Get(args);
            return Quaternion.LookRotation(direction);
        }

        public static GetQuaternion Create => new GetQuaternion(
            new TypeQuaternionTowardsDirection()
        );
        
        public static GetQuaternion CreateForward => new GetQuaternion(
            new TypeQuaternionTowardsDirection(Vector3.forward)
        );
        
        public static GetQuaternion CreateBackward => new GetQuaternion(
            new TypeQuaternionTowardsDirection(Vector3.back)
        );
        
        public static GetQuaternion CreateLeft => new GetQuaternion(
            new TypeQuaternionTowardsDirection(Vector3.left)
        );
        
        public static GetQuaternion CreateRight => new GetQuaternion(
            new TypeQuaternionTowardsDirection(Vector3.right)
        );

        public override string ToString() => $"Direction {this.m_Direction}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}