namespace FluentInteract
{
    public interface IAspect
    {
        bool IsMatch(IInteractor interactor, object input);
    }
}
