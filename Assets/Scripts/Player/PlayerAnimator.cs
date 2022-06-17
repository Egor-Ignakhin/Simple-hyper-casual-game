using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;

        [SerializeField] private PlayerMotion playerMotion;

        private int canRunHash;

        private void Awake()
        {
            canRunHash = Animator.StringToHash("CanRun");

            playerMotion.MotionStateChanged += OnPlayerMotionTypeChanged;
        }

        private void OnPlayerMotionTypeChanged(IPlayerMotionState playerMotionState)
        {
            UpdateAnimatorState(playerMotionState);
        }

        private void UpdateAnimatorState(IPlayerMotionState playerMotionState)
        {
            animator.SetBool(canRunHash, playerMotionState is RunPlayerMotionState);
        }

        private void OnDestroy()
        {
            playerMotion.MotionStateChanged -= OnPlayerMotionTypeChanged;
        }
    }
}