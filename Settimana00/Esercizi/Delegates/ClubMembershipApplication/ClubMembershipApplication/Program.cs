using ClubMembershipApplication.Factories;

namespace ClubMembershipApplication
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await ViewFactory
                .GetMainViewObject()
                .RunView();
        }
    }
}
