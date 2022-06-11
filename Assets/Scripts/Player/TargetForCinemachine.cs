using UnityEngine;

namespace SquareDinoTestWork.Player
{
    /// <summary>
    /// This script smooths camera movement
    /// </summary>
    public sealed class TargetForCinemachine : MonoBehaviour
    {
        private Transform playerParent;

        private Transform dummyTargetInParent;

        private void Start()
        {
            playerParent = transform.parent;

            dummyTargetInParent = new GameObject(nameof(TargetForCinemachine)).transform;
            dummyTargetInParent.SetParent(playerParent);
            dummyTargetInParent.localPosition = transform.localPosition;

            transform.SetParent(null);
        }

        private void LateUpdate()
        {
            transform.position = dummyTargetInParent.position;
        }
    }
}