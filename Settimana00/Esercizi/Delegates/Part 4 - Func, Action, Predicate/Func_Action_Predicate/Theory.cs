﻿namespace Func_Action_Predicate
{
    public class Theory
    {
        public class Delegates<TSource, TDestination>
        {
            // Func -> 
            public Func<TSource, TDestination> FuncExample(TSource src) => null!;

            // Action -> 
            public Action<TSource> ActionExample(TSource src) => null!;

            // Predicate -> 
            public Predicate<TSource> PredicateExample(TSource src) => null!;


            // Contravariance -> TSrc is controvariant in TDest 
            public delegate TDest Test<in TSrc, out TDest>(TSrc src)
                where TSrc : Animal
                where TDest : class;

            public static Test<Animal, string> fromAnimal = a => "It's an animal";
            public static Test<Dog, string> fromDog = fromAnimal;

            // TDest is covariant to superclass
            public delegate TDest Factory<out TDest>();
            public static Factory<Dog> createDog = () => new Dog();
            public static Factory<Animal> createAnimal = createDog;
        }

        public class Animal { }
        public class Dog : Animal { }
        public class Bird : Animal { }

        public class PracticalCovarianceAndContravarianceInAction
        {
            public delegate TResult Func<in T, out TResult>(T args);

            public void Test()
            {
                Func<Animal, Dog> FuncAnimal = MyTest;

                // IN: The delegate accepts a more specific T parameter
                // OUT: The delegate returns a more Generic TResult
                Func<Dog, Animal> FuncDog = FuncAnimal;
                Func<Bird, Animal> FuncBird = FuncAnimal;
            }

            private Dog MyTest(Animal s)
            {
                return new Dog();
            }
        }
    }
}

