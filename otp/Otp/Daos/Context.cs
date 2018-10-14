using System.Collections.Generic;

namespace Otp.Daos
{
    public static class Context
    {
        private static Dictionary<string, string> profiles;

        static Context()
        {
            profiles = new Dictionary<string, string>
            {
                {"joey", "91"}, 
                {"mei", "99"}
            };
        }

        public static string GetPassword(string key)
        {
            return profiles[key];
        }
    }
}