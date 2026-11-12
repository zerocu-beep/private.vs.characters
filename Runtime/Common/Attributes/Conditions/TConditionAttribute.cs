using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public abstract class TConditionAttribute : PropertyAttribute
    {
        public string[] Fields { get; }

        protected TConditionAttribute(params string[] fields)
        {
            this.Fields = fields;
        }
    }
}