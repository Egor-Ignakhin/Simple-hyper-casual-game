using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork
{
    [System.Serializable]
    public abstract class ObjectPool
    {
        protected Stack<PoolableObject> reusableInstances = new Stack<PoolableObject>();

        protected PoolableObject prefabAsset;

        public abstract void Initialize();

        protected abstract void SetPrefabAsset();

        public PoolableObject Pop()
        {
            return reusableInstances.Pop();
        }

        public void ReturnToPool(PoolableObject instance)
        {
            instance.gameObject.SetActive(false);

            reusableInstances.Push(instance);
        }

        public PoolableObject GetObjectFromPool()
        {
            PoolableObject retObject;
            if (reusableInstances.Count > 0)
            {
                retObject = reusableInstances.Pop();
                retObject.gameObject.SetActive(true);
            }
            else
                retObject = Object.Instantiate(prefabAsset);

            return retObject;
        }
    }
}