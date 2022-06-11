using UnityEngine;

namespace SquareDinoTestWork.Combat
{
    [System.Serializable]
    public sealed class BulletsPool : ObjectPool
    {
        [SerializeField] private Transform bulletsParent;

        [SerializeField] private int bulletsCount = 10;

        public override void Initialize()
        {
            SetPrefabAsset();

            for (int i = 0; i < bulletsCount; i++)
            {
                PoolableObject bulletInstance = Object.Instantiate(prefabAsset, bulletsParent);
                reusableInstances.Push(bulletInstance);
                bulletInstance.SetObjectPool(this);
            }
        }

        protected override void SetPrefabAsset()
        {
            prefabAsset = Resources.Load<Bullet>("BulletInstance");
        }
    }
}