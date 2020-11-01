using System;
using System.Threading;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (PasswordLenghtCheck(password) == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (PasswordConsistenceCheck(password) == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (PasswordDigitsCheck(password) == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (PasswordLenghtCheck(password) == true &&
                PasswordConsistenceCheck(password) == true &&
                PasswordDigitsCheck(password) == true)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasswordLenghtCheck(string password)
        {
            bool islenghtCheck = false;
            if (password.Length >= 6 && password.Length <= 10)
            {
                islenghtCheck = true;
            }

            return islenghtCheck;
        }

        static bool PasswordConsistenceCheck(string password)
        {
            bool consistCheck = false;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 48 && password[i] <= 57)
                    || (password[i] >= 65 && password[i] <= 90)
                    || (password[i] >= 97 && password[i] <= 122))
                {
                    consistCheck = true; ;
                }

                else
                {
                    consistCheck = false;
                    break;
                }
            }

            return consistCheck;
        }

        static bool PasswordDigitsCheck(string password)
        {
            int count = 0;
            bool digitCheck = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    count++;
                }
            }

            if (count >= 2)
            {
                digitCheck = true;
            }

            return digitCheck;
        }
    }
}
