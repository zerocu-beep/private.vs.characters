namespace VisualScript.Runtime.Characters.IK
{
    [System.Serializable]
    public abstract class TRigAnimatorIK : TRig
    {
        public sealed override void OnUpdate(Character character)
        {
            this.DoUpdate(character);
        }
    }
}