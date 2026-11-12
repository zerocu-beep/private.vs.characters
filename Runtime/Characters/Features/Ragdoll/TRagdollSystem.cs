using System.Threading.Tasks;

namespace VisualScript.Runtime.Characters
{
    [Title("Ragdoll")]
    
    [System.Serializable]
    
    public abstract class TRagdollSystem
    {
        // PUBLIC METHODS: ------------------------------------------------------------------------
        
        protected internal abstract void OnStartup(Character character);
        protected internal abstract void OnDispose(Character character);
        
        protected internal abstract void OnEnable(Character character);
        protected internal abstract void OnDisable(Character character);

        protected internal abstract void OnUpdate(Character character);
        protected internal abstract void OnLateUpdate(Character character);
        
        protected internal abstract Task StartRagdoll(Character character);
        protected internal abstract Task StopRagdoll(Character character);
        protected internal abstract Task RecoverRagdoll(Character character);

        protected internal abstract void OnDrawGizmos(Character character);
    }
}