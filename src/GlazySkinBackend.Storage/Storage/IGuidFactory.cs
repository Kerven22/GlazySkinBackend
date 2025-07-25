namespace GlazySkinBackend.Stroage.Storage;

public interface IGuidFactory
{
    Guid Create(); 
}

public class GuidFactory:IGuidFactory
{
    public Guid Create() => Guid.NewGuid();
}