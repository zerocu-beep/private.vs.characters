using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    [Serializable]
    public class RunConditionsList
    {
        [SerializeField] private Conditions m_Conditions;

        public bool IsEmpty => this.m_Conditions?.IsEmpty ?? true;

        public RunConditionsList()
        {
            this.m_Conditions = new Conditions();
        }

        public RunConditionsList(params Condition[] conditions)
        {
            this.m_Conditions = new Conditions(conditions);
        }

        public bool Check(Args args)
        {
            if (AppManager.IsExiting) return false;
            return this.m_Conditions?.Check(args, Conditions.DEFAULT_OPERATION) ?? true;
        }

        public override string ToString()
        {
            return this.m_Conditions?.ToString() ?? string.Empty;
        }
    }
}
