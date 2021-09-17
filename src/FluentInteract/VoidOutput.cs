namespace FluentInteract
{
    public class VoidOutput
    {
        public static VoidOutput Instance { get; private set; }

        static VoidOutput()
        {
            Instance = new VoidOutput();
        }
    }
}
