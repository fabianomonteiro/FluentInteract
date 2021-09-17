namespace FluentInteract.Aspects
{
    public interface IAuthorizingAspect : IAspect
    {
        bool Authorize(IInteractor interactor, IInput input);
    }
}
