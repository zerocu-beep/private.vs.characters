using System;

namespace VisualScript.Runtime.Characters
{
    public interface ITweenInput
    {
        // PROPERTIES: ----------------------------------------------------------------------------
        
        public int Hash { get; }
        public float Duration { get; }
        
        public bool IsFinished { get; }
        public bool IsComplete { get; }
        public bool IsCanceled { get; }

        // EVENTS: --------------------------------------------------------------------------------
        
        event Action<bool> EventFinish;
        
        // METHODS: -------------------------------------------------------------------------------

        bool OnUpdate();

        void OnComplete();
        void OnCancel();
    }
}