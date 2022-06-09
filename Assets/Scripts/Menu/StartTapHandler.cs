using SquareDinoTestWork.Plot;

using UnityEngine;
using UnityEngine.EventSystems;

namespace SquareDinoTestWork.Menu
{
    public sealed class StartTapHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject tapHintGM;
        [SerializeField] private PlotManager plotManager;

        public void OnPointerClick(PointerEventData eventData)
        {
            StartGame();
        }

        private void StartGame()
        {
            HideTapHint();

            plotManager.StartGame();
        }

        private void HideTapHint()
        {
            tapHintGM.SetActive(false);
        }
    }
}