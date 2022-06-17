using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public class NonePlayerMotionState : IPlayerMotionState
    {
        private PlayerMotion playerMotion;
        public NonePlayerMotionState(PlayerMotion playerMotion)
        {
            this.playerMotion = playerMotion;
        }

        public void SetIdle()
        {
            playerMotion.SetState(playerMotion.GetIdleState());
        }

        public void SetRun()
        {
            playerMotion.SetState(playerMotion.GetIdleState());
        }
    }
}
