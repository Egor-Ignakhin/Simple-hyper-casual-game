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

            playerMotion.MotionTypeChanged += OnPlayerMotionTypeChanged;
        }

        private void OnPlayerMotionTypeChanged(PlayerMotionTypes playerMotionType)
        {
            UpdateAnimatorState(playerMotionType);
        }

        private void UpdateAnimatorState(PlayerMotionTypes playerMotionType)
        {
            animator.SetBool(canRunHash, playerMotionType == PlayerMotionTypes.Run);
        }

        private void OnDestroy()
        {
            playerMotion.MotionTypeChanged -= OnPlayerMotionTypeChanged;
        }
    }
}