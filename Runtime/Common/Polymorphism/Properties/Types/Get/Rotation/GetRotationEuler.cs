using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Euler Angles")]
    [Category("Values/Euler Angles")]
    
    [Image(typeof(IconRotation), ColorTheme.Type.Yellow)]
    [Description("Rotation from the euler angle of each individual axis in world space")]

    [Get]

    [Serializable]
    public class TypeQuaternionRotationEuler : TypeQuaternion
    {
        [SerializeField] private GetNumber m_X = new GetNumber(0f);
        [SerializeField] private GetNumber m_Y = new GetNumber(0f);
        [SerializeField] private GetNumber m_Z = new GetNumber(0f);
        
        public override Quaternion Get(Args args)
        {
            float x = (float) this.m_X.Get(args);
            float y = (float) this.m_Y.Get(args);
            float z = (float) this.m_Z.Get(args);
            
            return Quaternion.Euler(new Vector3(x, y, z));
        }

        public TypeQuaternionRotationEuler()
        { }
        
        public TypeQuaternionRotationEuler(Vector3 angles)
        {
            this.m_X = new GetNumber(angles.x);
            this.m_Y = new GetNumber(angles.y);
            this.m_Z = new GetNumber(angles.z);
        }
        
        public TypeQuaternionRotationEuler(float x, float y, float z)
        {
            this.m_X = new GetNumber(x);
            this.m_Y = new GetNumber(y);
            this.m_Z = new GetNumber(z);
        }
        
        public TypeQuaternionRotationEuler(Transform transform)
            : this(transform != null ? transform.rotation.eulerAngles: Vector3.zero)
        { }
        
        public static GetQuaternion Create() => new GetQuaternion(
            new TypeQuaternionRotationEuler()
        );
        
        public static GetQuaternion Create(Vector3 euler) => new GetQuaternion(
            new TypeQuaternionRotationEuler(euler)
        );

        public override string ToString() => $"Euler ({this.m_X}, {this.m_Y}, {this.m_Z})";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}