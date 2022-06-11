using UnityEngine;

namespace SquareDinoTestWork
{
    public abstract class PoolableObject : MonoBehaviour
    {
        protected ObjectPool mPool;

        public void SetObjectPool(ObjectPool objectPool)
        {
            mPool = objectPool;
        }
    }
}