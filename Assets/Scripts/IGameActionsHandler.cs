using SquareDinoTestWork.Plot;

using System.Collections.Generic;

using UnityEngine;

namespace SquareDinoTestWork
{
    internal sealed class IGameActionsHandler : MonoBehaviour
    {
        [SerializeField] private List<GameObject> playerActionsGM = new List<GameObject>();

        private void Start()
        {
            GamePlot.LevelStarted += SetCanDoGameActions;
        }

        private void SetCanDoGameActions()
        {
            foreach (var playerActionGM in playerActionsGM)
            {
                IGameAction[] playerActions = playerActionGM.GetComponents<IGameAction>();
                foreach (IGameAction playerAction in playerActions)
                {
                    playerAction.CanDo = true;
                }
            }
        }

        private void OnDestroy()
        {
            GamePlot.LevelStarted -= SetCanDoGameActions;
        }
    }
}