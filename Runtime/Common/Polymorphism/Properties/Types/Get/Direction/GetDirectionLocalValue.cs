using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Local to World Direction")]
    [Category("Transforms/Local to World Direction")]
    
    [Image(typeof(IconVector3), ColorTheme.Type.Green)]
    [Description("Transforms the direction from Local Space to World Space")]
    
    [Keywords("Game Object")]
    [Get]
    [Serializable]
    public class TypeVector3DirectionLocalValue : TypeVector3
    {
        [SerializeField]
        protected GetGameObject m_Transform = new GetGameObject(new TypeGameObjectPlayer());

        [SerializeField]
        private GetVector3 m_Direction = new GetVector3();
        
        public override Vector3 Get(Args args)
        {
            Transform transform = this.m_Transform.Get<Transform>(args);
            Vector3 direction = this.m_Direction.Get(args);
            
            return transform != null 
                ? transform.TransformDirection(direction)
                : direction;
        }

        public static GetVector3 Create => new GetVector3(
            new TypeVector3DirectionLocalValue()
        );

        public static GetVector3 CreateSelf(Vector3 direction = default)
        {
            return new GetVector3(
                new TypeVector3DirectionLocalValue
                {
                    m_Transform = TypeGameObjectSource.Create(),
                    m_Direction = new GetVector3(direction)
                }
            );
        }
        
        public static GetVector3 CreateTarget(Vector3 direction = default)
        {
            return new GetVector3(
                new TypeVector3DirectionLocalValue
                {
                    m_Transform = TypeGameObjectTarget.Create(),
                    m_Direction = new GetVector3(direction)
                }
            );
        }
        
        public static GetVector3 CreatePlayer(Vector3 direction = default)
        {
            return new GetVector3(
                new TypeVector3DirectionLocalValue
                {
                    m_Transform = new GetGameObject(new TypeGameObjectPlayer()),
                    m_Direction = new GetVector3(direction)
                }
            );
        }
        
        public static GetVector3 CreateGameObject(GameObject gameObject, Vector3 direction)
        {
            return new GetVector3(
                new TypeVector3DirectionLocalValue
                {
                    m_Transform = new GetGameObject(new TypeGameObjectInstance(gameObject)),
                    m_Direction = new GetVector3(direction)
                }
            );
        }

        public override string ToString() => $"{this.m_Transform} {this.m_Direction}";
    
        protected override SubscriptionMode Subscription => SubscriptionMode.OnChange;
    }
}