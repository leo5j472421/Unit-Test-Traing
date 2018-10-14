using System.Collections.Generic;

namespace Otp.Daos
{
    public  class Context
    {
        protected static Dictionary<string, string> profiles;

        static Context()
        {
            profiles = new Dictionary<string, string>
            {
                {"joey", "91"}, 
                {"mei", "99"}
            };
        }

        public string GetPassword(string key)
        {
            return profiles[key];
        }
    }
}