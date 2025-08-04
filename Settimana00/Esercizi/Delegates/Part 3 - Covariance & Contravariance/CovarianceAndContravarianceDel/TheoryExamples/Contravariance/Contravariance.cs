namespace CovarianceAndContravarianceDel.TheoryExamples.Contravariance
{
    // Contravariance

    delegate void MyDelegate1(DerivedClass1 derivedClass1);
    delegate void MyDelegate2(DerivedClass2 derivedClass2);

    public class Contravariance
    {
        public static void TestContravariance()
        {
            // The associated method has a more generic (less derived) parameter despite the delegates paremeter's type
            MyDelegate1 myDelegate1 = TestContravarianceClass.MyMethod_Contravariance;
            MyDelegate2 myDelegate2 = TestContravarianceClass.MyMethod_Contravariance;
        }
    }

    public static class TestContravarianceClass
    {
        public static void MyMethod_Contravariance(BaseClass _) { }
    }

    public class DerivedClass1 : BaseClass { }
    public class DerivedClass2 : BaseClass { }
}

class Animal { }
class Dog : Animal { }
class Cat : Animal { }
class Bird : Animal { }

interface IConsumer<in T>
{
    void Consume(T src);
}

interface IProducer<out T> where T : Animal
{
    T Produce();
}

class AnimalProducer<TDest> : IProducer<TDest> where TDest : Animal, new()
{
    public TDest Produce() => new TDest();
}

class AnimalConsumer<TSrc> : IConsumer<TSrc>
{
    public void Consume(TSrc src)
    {
        throw new NotImplementedException();
    }
}

class Example
{
    void RunProduce()
    {
        IProducer<Dog> dog = new AnimalProducer<Dog>();
        IProducer<Cat> cat = new AnimalProducer<Cat>();
        IProducer<Bird> bird = new AnimalProducer<Bird>();
        IProducer<Animal> animal = dog;
        IProducer<Animal> animal2 = cat;
        IProducer<Animal> animal3 = bird;
    }

    void RunConsume()
    {
        IConsumer<Animal> animal = new AnimalConsumer<Animal>();
        IConsumer<Dog> dog = animal;
    }
}