namespace FluentInteract
{
    public class VoidOutput : IOutput
    {
        public static VoidOutput Instance { get; private set; }

        static VoidOutput()
        {
            Instance = new VoidOutput();
        }
    }
}
