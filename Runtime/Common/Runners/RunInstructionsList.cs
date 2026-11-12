using System;
using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// A list of Instructions that lives inside a non-scene object (a Character feature, an
    /// Animim State asset, a Weapon, a Reaction...). Each run executes on its own instance, so
    /// several Characters can run the same list at the same time.
    /// </summary>
    [Serializable]
    public class RunInstructionsList
    {
        private class CancelNever : ICancelToken
        {
            public bool Get => false;
        }

        private static readonly ICancelToken NEVER = new CancelNever();

        // EXPOSED MEMBERS: -----------------------------------------------------------------------

        [SerializeField] private Instructions m_Instructions;

        // MEMBERS: -------------------------------------------------------------------------------

        [NonSerialized] private InstanceInstructions m_Template;

        // PROPERTIES: ----------------------------------------------------------------------------

        public bool IsEmpty => this.m_Instructions?.IsEmpty ?? true;
        public Instructions Value => this.m_Instructions;

        // CONSTRUCTORS: --------------------------------------------------------------------------

        public RunInstructionsList()
        {
            this.m_Instructions = new Instructions();
        }

        public RunInstructionsList(params Instruction[] instructions)
        {
            this.m_Instructions = new Instructions(instructions);
        }

        public RunInstructionsList(Instructions instructions)
        {
            this.m_Instructions = new Instructions(instructions);
        }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public Awaitable Run(Args args) => this.Run(args, RunnerConfig.Default);

        public async Awaitable Run(Args args, RunnerConfig config)
        {
            if (AppManager.IsExiting) return;
            if (this.IsEmpty) return;

            if (this.m_Template == null)
            {
                this.m_Template = TInstance<Instructions>.CreateTemplate<InstanceInstructions>(
                    this.m_Instructions
                );
            }

            InstanceInstructions instance = this.m_Template.Create();
            try
            {
                await instance.Value.Run(args, config.Cancellable ?? NEVER);
            }
            finally
            {
                if (instance != null) UnityEngine.Object.Destroy(instance);
            }
        }

        // STRING: --------------------------------------------------------------------------------

        public override string ToString()
        {
            return this.m_Instructions?.ToString() ?? string.Empty;
        }
    }
}
