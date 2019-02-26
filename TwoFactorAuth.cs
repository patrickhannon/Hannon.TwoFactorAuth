using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hannon._2factorAuth.Models;
using hannon.TwoFactorAuth.Providers;
using hannon.TwoFactorAuth.Models;
using hannon.TwoFactorAuth;
using hannon.TwoFactorAuth.Util;
namespace hannon._2factorAuth
{
    public class TwoFactorAuth : ITwoFactorAuth
    {
        private EmailProvider _emailProvider;
        private SmsMessageTwilio _smsProvider;
        private InitTwoFactor _twoFactorConfigs;
        public TwoFactorAuth(InitTwoFactor model)
        {
            ArgumentValidator.ThrowOnNull("model", model);
            _twoFactorConfigs = model;
            _emailProvider = new EmailProvider(model.TwoFactorAuthSmtpHost, model.TwoFactorAuthFromEmail);
            _smsProvider = new SmsMessageTwilio(model.AccountSID, model.AuthToken, "SMS Verification Code");
        }

        public TwoFactorResponseModel CreateTwoFactorAuth(TwoFactorRequestModel model)
        {
            var response = new TwoFactorResponseModel();
            //create the key 
            var code = Helpers.GenerateRandomNumber();
            //send to provider
            switch (model.Provider)
            {
                case Provider.Email:
                    if (_emailProvider.SendEmail(model.UserValue, "Verification Code..",
                        string.Format("Your {0} Verification code is: {1}", "Company Here", code)))
                        response = new TwoFactorResponseModel()
                        {
                            Status = true,
                            Message = "Message successfully sent, please check your email."
                        };
                    break;
                case Provider.SMS:
                    var smsResponse = _smsProvider.SendMessage(_twoFactorConfigs.TwoFactorAuthFromPhone, model.UserValue,
                        string.Format("Your {0} Verification code is: {1}", "Company Here", code));
                        response  = new TwoFactorResponseModel()
                        {
                            Status = smsResponse.Status,
                            Message = smsResponse.Message
                        };
                    break;
                default:
                    response.Message = "Please define indicate which provider you want to use, sms or email.";
                    response.Status = false;
                break;
            }
            return response;
        }
        //IsVerified
        //SetSetCookieLength
        //Email
        //SMSMessage
        //

        public TwoFactorResponseModel VerifyCode(TwoFactorRequestModel model)
        {
            //create the key and send to provider
            //create a cookie by the name 
            //set the cookie life
            var response = new TwoFactorResponseModel();

            throw new NotImplementedException();
        }

    }
    public enum Provider { Email, SMS };
}
