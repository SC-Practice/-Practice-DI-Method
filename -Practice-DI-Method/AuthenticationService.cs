﻿using _Practice_DI_Method;
namespace _Practice_DI_Constructor
{
    public class AuthenticationService
    {
        public AuthenticationService()
        {
        }

        #region 驗證的副程式

        internal bool TwoFactorLogin(string userId, string pwd, IMessageService service)
        {
            // 檢查帳號密碼，若正確，則傳回一個包含使用者資訊的物件。
            User user = CheckPassword(userId, pwd);
            if (user != null)
            {
                // 接著發送驗證碼給使用者，假設隨機產生的驗證碼為"123456"。
                service.Send(user, " 您的登入驗證碼為 123456");
                return true;
            }

            return false;
        }

        public bool VerifyToken(string verifyToken)
        {
            if (verifyToken == "123456")
            {
                return true;
            }

            return false;
        }

        private User CheckPassword(string userId, string pwd)
        {
            if (true)
            {
                return new User();
            }
        }

        #endregion 驗證的副程式
    }
}