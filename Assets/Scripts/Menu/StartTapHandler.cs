using SquareDinoTestWork.Plot;

using UnityEngine;
using UnityEngine.EventSystems;

namespace SquareDinoTestWork.Menu
{
    public sealed class StartTapHandler : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject tapHintGM;

        public void OnPointerClick(PointerEventData eventData)
        {
            StartLevel();
        }

        private void StartLevel()
        {
            HideTapHint();

            GamePlot.StartLevel();
        }

        private void HideTapHint()
        {
            tapHintGM.SetActive(false);
        }
    }
}