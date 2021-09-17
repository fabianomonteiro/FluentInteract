namespace FluentInteract
{
    public class VoidInput : IInput
    {
        public static VoidInput Instance { get; private set; }

        static VoidInput()
        {
            Instance = new VoidInput();
        }
    }
}
