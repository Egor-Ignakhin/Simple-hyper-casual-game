using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
      
        private PlayerMotionTypes currentMotionType;

        private int canRunHash;

        private void Awake()
        {
            canRunHash = Animator.StringToHash("CanRun");
        }

        public void SetAnimatorState(PlayerMotionTypes motionType)
        {
            currentMotionType = motionType;

            UpdateAnimatorState();
        }

        private void UpdateAnimatorState()
        {
            animator.SetBool(canRunHash, currentMotionType == PlayerMotionTypes.Run);
        }
    }
}