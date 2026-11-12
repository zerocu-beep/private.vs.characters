using UnityEngine;

namespace VisualScript.Runtime.Characters
{
    public struct RunnerConfig
    {
        public static readonly RunnerConfig Default = new RunnerConfig();

        public string Name { get; set; }
        public RunnerLocationLocation Location { get; set; }
        public ICancelToken Cancellable { get; set; }
    }

    public readonly struct RunnerLocationLocation
    {
        public readonly Vector3 Position;
        public readonly Quaternion Rotation;

        public RunnerLocationLocation(Vector3 position, Quaternion rotation)
        {
            this.Position = position;
            this.Rotation = rotation;
        }
    }
}
