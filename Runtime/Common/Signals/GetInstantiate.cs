using System;
using UnityEngine;
using VisualScript.Icons;

namespace VisualScript.Runtime.Characters
{
    /// <summary>
    /// A Game Object signal that is used as a prefab: it can instantiate it, optionally using
    /// the Visual Script Pool Manager.
    /// </summary>
    [Title("Instantiate Game Object")]
    [Category("Get Game Object")]
    [Image(typeof(IconCubeOutline), ColorTheme.Type.Blue)]
    [Serializable]
    public class GetInstantiate : GetGameObject
    {
        public bool usePooling = false;
        public int size = 5;
        public bool hasDuration;
        public float duration = 10f;

        // CONSTRUCTORS: --------------------------------------------------------------------------

        public GetInstantiate() : base(new TypeGameObjectInstance())
        { }

        public GetInstantiate(TypeGameObject value) : base(value)
        { }

        // PUBLIC METHODS: ------------------------------------------------------------------------

        public GameObject Get(Args args, Vector3 position)
        {
            return this.Get(args, position, Quaternion.identity, null);
        }

        public GameObject Get(Args args, Vector3 position, Quaternion rotation)
        {
            return this.Get(args, position, rotation, null);
        }

        public GameObject Get(Args args, Vector3 position, Quaternion rotation, Transform parent)
        {
            GameObject prefab = this.Get(args);
            if (prefab == null) return null;

            if (!this.usePooling)
            {
                return UnityEngine.Object.Instantiate(prefab, position, rotation, parent);
            }

            GameObject instance = PoolManager.Pick(
                prefab, position, rotation,
                this.size, this.hasDuration ? this.duration : -1f,
                TimeMode.GameTime
            );

            if (instance != null && parent != null) instance.transform.SetParent(parent);
            return instance;
        }

        public GameObject Get(GameObject target, Vector3 position)
        {
            using Args args = Args.Get(target, target);
            return this.Get(args, position, Quaternion.identity, null);
        }

        public GameObject Get(GameObject target, Vector3 position, Quaternion rotation)
        {
            using Args args = Args.Get(target, target);
            return this.Get(args, position, rotation, null);
        }

        public GameObject Get(GameObject target, Vector3 position, Quaternion rotation, Transform parent)
        {
            using Args args = Args.Get(target, target);
            return this.Get(args, position, rotation, parent);
        }
    }
}
