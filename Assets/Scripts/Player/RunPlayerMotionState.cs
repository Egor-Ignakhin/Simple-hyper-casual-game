using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public class RunPlayerMotionState : IPlayerMotionState
    {
        private PlayerMotion playerMotion;

        public RunPlayerMotionState(PlayerMotion playerMotion)
        {
            this.playerMotion = playerMotion;
        }

        public void SetIdle()
        {
            playerMotion.SetState(playerMotion.GetIdleState());
        }

        public void SetRun()
        {
            Debug.Log("You already running!");
        }
    }
}