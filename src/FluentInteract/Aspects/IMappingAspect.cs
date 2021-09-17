using System.Threading.Tasks;

namespace FluentInteract.Aspects
{
    public interface IMappingAspect : IAspect
    {
        Task<TDestination> Map<TSource, TDestination>(TSource source);
    }
}
