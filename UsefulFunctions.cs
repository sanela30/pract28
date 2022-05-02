using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace pract28
{
    internal class UsefulFunctions
    {

        public static string RandomEmail()
        {
            string email_part1,email_part2,email_part3;
            email_part1 = RandomAlphaNumeric(15);
            email_part2 = RandomAlphaNumeric(15);
            email_part3 = RandomAlphaNumeric(5);

            return email_part1 + "@" + email_part2 + "." + email_part3;
        }

       
        public static string RandomAlphaNumeric(int len=10)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random= new Random();

            var bulider = new StringBuilder();

            for (int i=0; i<len; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                bulider.Append(c);
            }


            return bulider.ToString();
        }
        public static string RandomPassword(int length1 = 10)
        {

            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*_-";
            Random random = new Random();

            var bulider = new StringBuilder();

            for (int i = 0; i< length1; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                bulider.Append(c);
            }


            return bulider.ToString();
        }

    }
}
