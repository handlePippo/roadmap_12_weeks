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
