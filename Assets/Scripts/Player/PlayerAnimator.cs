using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] Animator animator;
      
        private PlayerAnimatorStates currentState;

        private int canRunHash;

        private void Awake()
        {
            canRunHash = Animator.StringToHash("CanRun");
        }

        public void SetAnimatorState(PlayerAnimatorStates state)
        {
            currentState = state;

            UpdateAnimatorState();
        }

        private void UpdateAnimatorState()
        {
            animator.SetBool(canRunHash, currentState == PlayerAnimatorStates.Run);
        }
    }
}