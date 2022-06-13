using UnityEngine;

namespace SquareDinoTestWork.Enemies
{
    public sealed class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private EnemyHealth enemyHealth;

        [SerializeField] private Rigidbody[] ragdollRbs;

        private void Awake()
        {
            enemyHealth.EnemyDied += OnEnemyDied;

            SetEnableRagdoll(false);
        }

        private void OnEnemyDied(EnemyHealth _)
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
            enemyHealth.EnemyDied -= OnEnemyDied;
        }
    }
}