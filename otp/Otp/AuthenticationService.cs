using System;
using Otp.Daos;

namespace Otp
{
    public class AuthenticationService
    {
        private ProfileDao profileDao;
        private RsaTokenDao rsaToken;

        public AuthenticationService()
        {
            profileDao = new ProfileDao(new Context());
            rsaToken = new RsaTokenDao(false);
        }

        public AuthenticationService(ProfileDao _p , RsaTokenDao _r)
        {
            profileDao = _p ;
            rsaToken = _r ;
        }
        public bool IsValid(string account, string passcode)
        {
            // 根據 account 取得自訂密碼
           
            var passwordFromDao = profileDao.GetPassword(account);

            // 根據 account 取得 RSA token 目前的亂數
            var randomCode = rsaToken.GetRandom();

            // 驗證傳入的 password 是否等於自訂密碼 + RSA token亂數
            var validPassword = passwordFromDao + randomCode;


            Console.WriteLine("randomCode:{0}", validPassword);

            return passcode == validPassword;
        }
    }


}