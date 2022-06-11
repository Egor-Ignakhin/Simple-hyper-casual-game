using UnityEngine;

namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private Enemy enemy;

        [SerializeField] private Rigidbody[] ragdollRbs;

        private void Awake()
        {
            enemy.EnemyDied += OnEnemyDied;

            SetEnableRagdoll(false);
        }

        private void OnEnemyDied(Enemy _)
        {
            SetEnableRagdoll(true);
        }

        private void SetEnableRagdoll(bool value)
        {            
            foreach (var rb in ragdollRbs)
            {
                rb.isKinematic = !value;
            }
            animator.enabled = !value;
        }

        private void OnDestroy()
        {
            enemy.EnemyDied -= OnEnemyDied;
        }
    }
}