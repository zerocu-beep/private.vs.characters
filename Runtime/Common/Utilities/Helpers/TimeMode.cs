using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// The time a Character (or camera, or animation) runs on. It is stored as the Visual Script
    /// TimeMode, so the inspector shows the same Game Time / Real Time dropdown as the rest of
    /// Visual Script. GameTime and RealTime keep the values of Game Creator's GameTime and
    /// UnscaledTime, so existing assets load unchanged.
    /// </summary>
    [Serializable]
    public struct CharacterTime
    {
        public enum UpdateMode
        {
            GameTime = TimeMode.GameTime,
            UnscaledTime = TimeMode.RealTime
        }

        // MEMBERS: -------------------------------------------------------------------------------

        [SerializeField] private TimeMode m_UpdateTime;

        // PROPERTIES: ----------------------------------------------------------------------------

        public TimeMode Mode => this.m_UpdateTime;
        public UpdateMode UpdateTime => (UpdateMode) this.m_UpdateTime;

        public ITimeScale TimeScaleSource => VisualScript.Runtime.TimeScale.Get(this.m_UpdateTime);

        private bool IsGameTime => this.m_UpdateTime == TimeMode.GameTime;

        public float Time => this.IsGameTime ? UnityEngine.Time.time : UnityEngine.Time.unscaledTime;
        public float DeltaTime => this.IsGameTime ? UnityEngine.Time.deltaTime : UnityEngine.Time.unscaledDeltaTime;
        public float FixedTime => this.IsGameTime ? UnityEngine.Time.fixedTime : UnityEngine.Time.fixedUnscaledTime;
        public float FixedDeltaTime => this.IsGameTime ? UnityEngine.Time.fixedDeltaTime : UnityEngine.Time.fixedUnscaledDeltaTime;
        public float TimeScale => this.IsGameTime ? UnityEngine.Time.timeScale : 1f;

        public int Frame => UnityEngine.Time.frameCount;
        public int RenderedFrame => UnityEngine.Time.renderedFrameCount;

        public double TimeAsDouble => this.IsGameTime
            ? UnityEngine.Time.timeAsDouble
            : UnityEngine.Time.unscaledTimeAsDouble;

        public double FixedTimeAsDouble => this.IsGameTime
            ? UnityEngine.Time.fixedTimeAsDouble
            : UnityEngine.Time.fixedUnscaledTimeAsDouble;

        // CONSTRUCTORS: --------------------------------------------------------------------------

        public CharacterTime(UpdateMode mode)
        {
            this.m_UpdateTime = (TimeMode) mode;
        }

        public CharacterTime(TimeMode mode)
        {
            this.m_UpdateTime = mode;
        }

        // CONVERSIONS: ---------------------------------------------------------------------------

        public static implicit operator TimeMode(CharacterTime time) => time.m_UpdateTime;
        public static implicit operator CharacterTime(TimeMode mode) => new CharacterTime(mode);
    }
}
