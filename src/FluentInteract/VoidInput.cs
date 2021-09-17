namespace FluentInteract
{
    public class VoidInput
    {
        public static VoidInput Instance { get; private set; }

        static VoidInput()
        {
            Instance = new VoidInput();
        }
    }
}
