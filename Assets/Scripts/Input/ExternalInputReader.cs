namespace Assets.Scripts.Input
{
    public class ExternalInputReader : IInputReader
    {
        public float HorizontalDirection => UnityEngine.Input.GetAxisRaw("Horizontal");
        public float VerticalDirection => UnityEngine.Input.GetAxisRaw("Vertical");
    }
}
