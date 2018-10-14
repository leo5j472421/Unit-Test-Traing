using System.Collections.Generic;

namespace Otp.Daos
{
    public class ProfileDao
    {
        private Context context;

        public ProfileDao(Context c_ )
        {
            context = c_ ;
        }
        public string GetPassword(string account)
        {
            return context.GetPassword(account);
        }
    }

    public class fakeContext : Context{
        public fakeContext()
        {
            profiles = new Dictionary<string, string>
            {
                {"joey", "91"},
                {"mei", "99"},
                {"marcus","86" }
            };
        }
    }
}