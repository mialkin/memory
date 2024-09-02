namespace Memory.Api.Endpoints.Lohs.GenerateLargeStrings;

public class ClassWithFinalizer
{
    ~ClassWithFinalizer()
    {
        Console.WriteLine("Finalized");
    }
}
