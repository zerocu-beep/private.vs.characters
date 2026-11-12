using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public enum SpatialBlending
    {
        None,
        Spatial
    }

    /// <summary>
    /// Sound effect settings used by Characters (footsteps, impacts...), played through the
    /// Visual Script Audio Manager.
    /// </summary>
    public readonly struct AudioConfigSoundEffect
    {
        public readonly float Volume;
        public readonly Vector2 Pitch;
        public readonly float Transition;
        public readonly CharacterTime.UpdateMode Time;
        public readonly SpatialBlending Blending;
        public readonly GameObject Target;

        private AudioConfigSoundEffect(float volume, Vector2 pitch, float transition,
            CharacterTime.UpdateMode time, SpatialBlending blending, GameObject target)
        {
            this.Volume = volume;
            this.Pitch = pitch;
            this.Transition = transition;
            this.Time = time;
            this.Blending = blending;
            this.Target = target;
        }

        public static AudioConfigSoundEffect Create(float volume, Vector2 pitch, float transition,
            CharacterTime.UpdateMode time, SpatialBlending blending, GameObject target)
        {
            return new AudioConfigSoundEffect(volume, pitch, transition, time, blending, target);
        }
    }

    public static class CharacterAudio
    {
        private const float MIN_DISTANCE = 1f;
        private const float MAX_DISTANCE = 50f;

        public static void Play(AudioClip clip, AudioConfigSoundEffect config, Args args)
        {
            if (clip == null) return;

            ITimeScale timeScale = config.Time == CharacterTime.UpdateMode.GameTime
                ? TimeScale.GameTime
                : TimeScale.RealTime;

            GameObject target = config.Target;
            AudioConfig audioConfig = new AudioConfig(
                timeScale,
                config.Transition,
                AudioChannel.SoundEffect,
                false,
                128,
                config.Volume,
                Random.Range(config.Pitch.x, config.Pitch.y),
                0f,
                config.Blending == SpatialBlending.Spatial ? 1f : 0f,
                1f,
                AudioRolloffMode.Logarithmic,
                MIN_DISTANCE,
                MAX_DISTANCE,
                1f,
                0f,
                0f,
                0f,
                target != null,
                target,
                target != null ? target.transform : null,
                target != null ? target.transform.position : Vector3.zero
            );

            AudioManager.Play(clip, audioConfig);
        }
    }
}
