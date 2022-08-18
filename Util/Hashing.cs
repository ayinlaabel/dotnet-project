using BCrypt.Net;

namespace salvage_portal.Util
{
    public class Hashing
    {
        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GetRandomSalt());
        }

        public static bool ComparePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }
}