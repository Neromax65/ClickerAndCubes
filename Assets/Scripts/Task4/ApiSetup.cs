namespace Task4
{
    
    public static class Extensions
    {
        public static void SetupObjectA<T>(this ApiSetup<T> apiSetup) where T: ISomeInterfaceA
        {
            // Setup Object A
        }
        
        public static void SetupObjectB<T>(this ApiSetup<T> apiSetup) where T: ISomeInterfaceB
        {
            // Setup Object B
        }
    }
    
    public struct ApiSetup<T>
    {

    }
    class Api
    {
        public ApiSetup<T> For<T>(T obj)
        {
            return new ApiSetup<T>();
        }
        
    }

    public interface ISomeInterfaceA { }

    public interface ISomeInterfaceB { }

    public class ObjectA : ISomeInterfaceA { }

    public class ObjectB : ISomeInterfaceB { }
    
    class SomeClass
    {
        public void Setup()
        {
            Api apiObject = new Api();

            apiObject.For(new ObjectA()).SetupObjectA();
            apiObject.For(new ObjectB()).SetupObjectB();
        }
    }
}