# FluentInteract

NuGet:

https://www.nuget.org/packages/FluentInteract/

Registrando Aspectos via injeção de dependência:

```csharp
services.AddSingleton<IAspectWeaver, AspectWeaver>((serviceProvider) =>
{
    var aspectWeaver = new AspectWeaver();

    aspectWeaver.AddAspect<AuthorizingAspect>();
    aspectWeaver.AddAspect<CachingAspect>();
    aspectWeaver.AddAspect<CanExecutingAspect>();
    aspectWeaver.AddAspect<ChangingExecuteAspect>();
    aspectWeaver.AddAspect<LoggingAspect>();
    aspectWeaver.AddAspect<ValidatingAspect>();

    return aspectWeaver;
});
```
Aspecto de Autorização:

```csharp
public class AuthorizingAspect : IAuthorizingAspect
{
    public bool IsMatch(IInteractor interactor, object input)
    {
        return true;
    }

    public Task<bool> Authorize(IInteractor interactor, object input)
    {
        return Task.FromResult(true);
    }
}
```
Aspecto de Cache:

```csharp
public class CachingAspect : CachingAspectBase
{
    public override bool IsMatch(IInteractor interactor, object input)
    {
        return false;
    }

    public async override Task<object> GetCache(IInteractor interactor, object input)
    {
        return await Task.FromResult(new object());
    }
}
```
Aspecto de CanExecute:

```csharp
public class CanExecutingAspect : ICanExecutingAspect
{
    public bool IsMatch(IInteractor interactor, object input)
    {
        return true;
    }

    public Task<bool> CanExecute(IInteractor interactor, object input)
    {
        return Task.FromResult(true);
    }
}
```
Aspecto de ChangingExecute:

```csharp
public class ChangingExecuteAspect : IChangingExecuteAspect
{
    public bool IsMatch(IInteractor interactor, object input)
    {
        return false;
    }

    public Task<object> Execute(IInteractor interactor, object input)
    {
        return Task.FromResult(new object());
    }
}
```
Aspecto de Logging:

```csharp
public class LoggingAspect : ILoggingAspect
{
    public bool IsMatch(IInteractor interactor, object input)
    {
        return true;
    }

    public Task LogStartExecute(DateTime dateTime, IInteractor interactor, object input, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
    {
        Console.WriteLine("Start Execute");

        return Task.CompletedTask;
    }

    public Task LogEndExecute(DateTime dateTime, IInteractor interactor, TimeSpan elapsed, bool executeFromAspect, IAspect aspectExecutedInstance)
    {
        Console.WriteLine("End Execute");

        return Task.CompletedTask;
    }

    public Task LogExceptionExecute(DateTime dateTime, IInteractor interactor, object input, Exception exception, ICallerInstance callerInstance, string memberName, string sourceFilePath, int sourceLineNumber)
    {
        Console.WriteLine("Exception Execute");

        return Task.CompletedTask;
    }
}
```
Aspecto de Validating:

```csharp
public class ValidatingAspect : IValidatingAspect
{
    public bool IsMatch(IInteractor interactor, object input)
    {
        return true;
    }

    public Task<bool> Validate(IInteractor interactor, object input)
    {
        return Task.FromResult(true);
    }
}
```
