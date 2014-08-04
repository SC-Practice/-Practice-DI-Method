using _Practice_DI_Constructor;
using System;

namespace _Practice_DI_Method
{
    enum MessageSendType
    {
        Email,
        ShortMessage
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Login("", "");

            Console.Read();
        }

        public static void Login(string userId, string password)
        {
            var authService = new AuthenticationService();
            var messageSendType = MessageSendType.Email;

            IMessageService msgService = null;

            switch (messageSendType)
            {
                case MessageSendType.Email:
                    msgService = new EmailService();
                    break;
                case MessageSendType.ShortMessage:
                    msgService = new ShortMessageService();
                    break;
                default:
                    throw new ArgumentException(" 無效的訊息服務型別!");
            }
            
            #region 使用 authService 物件進行驗證判斷

            if (authService.TwoFactorLogin(userId, password, msgService))
            {
                if (authService.VerifyToken("123456"))
                {
                    // 登入成功。
                    Console.WriteLine("登入成功");
                    return;
                }
            }

            // 登入失敗。
            Console.WriteLine("登入失敗");

            #endregion 使用 authService 物件進行驗證判斷
        }
    }
}