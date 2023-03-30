using UnityEngine;

namespace Assets.Scripts.Input
{
    public class GameUIInputReader : MonoBehaviour, IInputReader
    {
        [SerializeField] private Joystick _joystick;

        public float HorizontalDirection => _joystick.Horizontal;
        public float VerticalDirection => _joystick.Vertical;
    }
}
