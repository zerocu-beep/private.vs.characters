using System;
using VisualScript.Icons;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Title("Handle")]
    [Category("Handle")]
    
    [Image(typeof(IconHandle), ColorTheme.Type.Yellow)]
    
    [Serializable]
    public class HandleItem : TPolymorphicItem<HandleItem>
    {
        [SerializeField] private RunConditionsList m_Conditions = new RunConditionsList();
        
        [SerializeField] private Bone m_Bone = new Bone(HumanBodyBones.RightHand);
        [SerializeField] private GetVector3 m_LocalPosition = new GetVector3();
        [SerializeField] private GetQuaternion m_LocalRotation = new GetQuaternion();
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public Bone Bone => this.m_Bone;

        public override string Title
        {
            get
            {
                string conditions = this.m_Conditions.ToString(); 
                return string.IsNullOrEmpty(conditions) ? "Default" : conditions;
            }
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        public bool CheckConditions(Args args) => this.m_Conditions.Check(args);

        public Vector3 GetPosition(Args args) => this.m_LocalPosition.Get(args);
        public Quaternion GetRotation(Args args) => this.m_LocalRotation.Get(args);
    }
}