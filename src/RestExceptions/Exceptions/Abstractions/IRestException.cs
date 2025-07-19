namespace RestExceptions;

public interface IRestException
{
    static abstract string DefaultMessage { get; }
}
