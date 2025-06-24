namespace Func_Action_Predicate
{
    internal class Program
    {
        static void Main(string[] _)
        {

            Console.ReadLine();
        }
    }

    public class Delegates<TSource, TDestination>
    {
        // Func -> 
        public Func<TSource, TDestination> FuncExample(TSource src) => null!;

        // Action -> 
        public Action<TSource> ActionExample(TSource src) => null!;

        // Predicate -> 
        public Predicate<TSource> PredicateExample(TSource src) => null!;



        // Contravariance -> TSource is controvariant in TDestination 
        public delegate TDest Test<in T, out TDest>(T src) 
            where T : Animal
            where TDest : class;

        public static Test<Animal, string> fromAnimal = a => "It's an animal";
        public static Test<Dog, string> fromDog = fromAnimal;

        // TDest is covariant to superclass
        public delegate TDest Factory<out TDest>();
        public static Factory<Dog> createDog = () => new Dog();
        public static Factory<Animal> createAnimal = createDog;

    }

    public class Animal
    {

    }

    public class Dog : Animal
    {

    }
}

