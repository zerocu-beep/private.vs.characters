using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Hotspots
{
    [Title("Play Sound")]
    [Keywords("Audio", "Sounds")]
    [Image(typeof(IconMusicNote), ColorTheme.Type.Yellow)]
    
    [Category("Audio/Play Sound")]
    [Description(
        "Plays a User Interface sound effect when the Hotspot is activated or deactivated"
    )]

    [Serializable]
    public class SpotSound : Spot
    {
        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] protected GetAudioResource m_OnActivate = new GetAudioResource();
        [SerializeField] protected GetAudioResource m_OnDeactivate = new GetAudioResource();

        [SerializeField]
        private AudioFieldUI m_AudioSettings = new AudioFieldUI();

        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private bool m_WasActive;
        
        // PROPERTIES: ----------------------------------------------------------------------------

        public override string Title => $"Play {this.m_OnActivate} / {this.m_OnDeactivate}";

        // OVERRIDE METHODS: ----------------------------------------------------------------------

        public override void OnEnable(Hotspot hotspot)
        {
            base.OnEnable(hotspot);
            this.m_WasActive = false;
        }

        public override void OnDisable(Hotspot hotspot)
        {
            base.OnDisable(hotspot);
            if (AppManager.IsExiting) return;
            
            if (this.m_WasActive)
            {
                Args args = Args.Get(hotspot.gameObject, hotspot.Target);
                UnityEngine.Audio.AudioResource audioClip = this.m_OnDeactivate.Get(args);
                
                if (audioClip != null)
                {
                    AudioManager.Play(audioClip, this.m_AudioSettings.Get(args));
                }
            }
        }

        public override void OnUpdate(Hotspot hotspot)
        {
            base.OnUpdate(hotspot);

            switch (this.m_WasActive)
            {
                case false when hotspot.IsActive:
                {
                    Args args = Args.Get(hotspot.gameObject, hotspot.Target);
                    UnityEngine.Audio.AudioResource audioClip = this.m_OnActivate.Get(args);
                    if (audioClip != null)
                    {
                        AudioManager.Play(audioClip, this.m_AudioSettings.Get(args));
                    }

                    break;
                }
                case true when !hotspot.IsActive:
                {
                    Args args = Args.Get(hotspot.gameObject, hotspot.Target);
                    UnityEngine.Audio.AudioResource audioClip = this.m_OnDeactivate.Get(args);
                    if (audioClip != null)
                    {
                        AudioManager.Play(audioClip, this.m_AudioSettings.Get(args));
                    }

                    break;
                }
            }


            this.m_WasActive = hotspot.IsActive;
        }
    }
}