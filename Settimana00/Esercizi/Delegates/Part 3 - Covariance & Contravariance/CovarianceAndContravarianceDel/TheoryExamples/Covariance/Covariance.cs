namespace CovarianceAndContravarianceDel.TheoryExamples.Covariance
{
    // Covariance

    delegate BaseClass MyDelegate();
    public class Covariance
    {
        // More derived return type that the MyDelegate delegate's return type
        MyDelegate myDelegate = TestCovarianceClass.MyMethod_Covariance;
    }

    public static class TestCovarianceClass
    {
        public static DerivedClass MyMethod_Covariance()
        {
            return new DerivedClass();
        }
    }
    public class DerivedClass : BaseClass { }
}
