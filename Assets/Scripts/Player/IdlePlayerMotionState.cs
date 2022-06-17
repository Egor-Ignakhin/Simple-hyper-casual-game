using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public class IdlePlayerMotionState : IPlayerMotionState
    {
        private PlayerMotion playerMotion;

        public IdlePlayerMotionState(PlayerMotion playerMotion)
        {
            this.playerMotion = playerMotion;
        }

        public void SetIdle()
        {
            Debug.Log("You already idling!");
        }

        public void SetRun()
        {
            playerMotion.SetState(playerMotion.GetRunState());
        }
    }
}