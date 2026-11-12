using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public interface IMaterialSound
    {
        public float Volume { get; }
        public AudioClip Audio { get; }
        
        public PoolField Impact { get; }
    }
}