
using UnityEngine;

namespace SquareDinoTestWork.Player
{
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField, Range(0, 2)] private int shootMousebutton;

        internal bool ShootButtonDown()
        {
           return Input.GetMouseButtonDown(shootMousebutton);
        }
    }
}