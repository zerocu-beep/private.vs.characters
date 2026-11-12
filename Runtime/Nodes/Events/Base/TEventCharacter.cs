using System;
using System.Reflection;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// Base class for every Character Trigger. Subscribes to the Character resolved by the
    /// Source signal and re-subscribes automatically when that Character changes (for example
    /// when another Character becomes the Player).
    /// </summary>
    [Serializable]
    public abstract class TEventCharacter : TriggerSourceComponentBase<Character>
    {
        // CONSTRUCTORS: --------------------------------------------------------------------------

        protected TEventCharacter() : base(new TypeGameObjectPlayer())
        { }

        // PROPERTIES: ----------------------------------------------------------------------------

        protected Character m_Character => this.m_CurrentSource;

        protected override string GetTitle(GameObject source)
        {
            string title = this.GetType().GetCustomAttribute<TitleAttribute>()?.Title ?? string.Empty;
            if (title.StartsWith("On ")) title = title.Substring(3);

            string member = TextUtils.ThemeAsKeyword(title);
            return $"{this.SourceName} {member}";
        }

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        protected sealed override void OnSourceChanged(Character previousSource, Character newSource)
        {
            if (previousSource != null) this.WhenDisabled(previousSource);
            if (newSource != null) this.WhenEnabled(newSource);
        }

        // PROTECTED METHODS: ---------------------------------------------------------------------

        protected void Execute(GameObject target)
        {
            using Args args = Args.Get(this.Component, target);
            this.Run(args);
        }

        // ABSTRACT METHODS: ----------------------------------------------------------------------

        protected abstract void WhenEnabled(Character character);
        protected abstract void WhenDisabled(Character character);
    }
}
