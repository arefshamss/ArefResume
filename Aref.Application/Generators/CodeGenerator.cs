using System.Text;

namespace Aref.Application.Generators
{
    public static class CodeGenerator
    {
        public static string GenerateUniqueStringCode()
            => Guid.NewGuid().ToString().Replace("-", "");

        public static int GenerateRandomIntegerCode()
            => new Random().Next(100000, 999999);

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateUniqueIdentifier()
        {
            var chars = "ABCDEFGHKLMNPQRSTUVWYZ23456789";
            Random random = new();

            var code = new StringBuilder();
            code.Append(chars[random.Next(0, 23)]);
            for (int i = 1; i < 6; i++)
            {
                if (i == 0)
                {
                    code.Append(chars[random.Next(0, 31)]);
                }
                else
                {
                    code.Append(random.Next(0, 10));
                }
            }

            return code.ToString();
        }
    }
}