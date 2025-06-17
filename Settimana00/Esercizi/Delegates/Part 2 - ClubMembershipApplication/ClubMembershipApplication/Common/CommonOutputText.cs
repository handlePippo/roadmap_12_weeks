namespace ClubMembershipApplication.Common
{
    public static class CommonOutputText
    {
        private static string MainHeading
        {
            get
            {
                string heading = "Cycling Club";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string RegistrationHeading
        {
            get
            {
                string heading = "Register";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string LoginHeading
        {
            get
            {
                string heading = "Login";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        public static void WriteMainHeading()
        {
            WriteHeading(MainHeading);

        }

        public static void WriteRegistrationHeading()
        {
            WriteHeading(RegistrationHeading);
        }

        public static void WriteLoginHeading()
        {
            WriteHeading(LoginHeading);
        }

        private static void WriteHeading(string heading)
        {
            Console.Clear();
            Console.WriteLine(heading);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
