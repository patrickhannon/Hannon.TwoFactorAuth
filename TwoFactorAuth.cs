using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using hannon._2factorAuth.Models;
using hannon.TwoFactorAuth.Providers;
using hannon.TwoFactorAuth.Models;
using hannon.TwoFactorAuth;
using hannon.TwoFactorAuth.Util;
using System.Diagnostics;
using Hannon.Utils;
using Twilio.Jwt.Taskrouter;

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
            _emailProvider = new EmailProvider(
                model.TwoFactorAuthSmtpHost, 
                model.TwoFactorAuthFromEmail,
                model.EmailPassword);
            _smsProvider = new SmsMessageTwilio(model.AccountSID, model.AuthToken, "SMS Verification Code");
        }

        public TwoFactorResponseModel CreateTwoFactorAuth(TwoFactorRequestModel model, 
            HttpSessionStateBase session)
        {
            var response = new TwoFactorResponseModel();
            //create the key 
            var code = Helpers.GenerateRandomNumber();
            //set the code in the session 
            session["AuthCode"] = code;
            var codeMess = string.Format("The generated code is: {0}", code);
            Debug.WriteLine(codeMess);
            Utils.LogToEventLog("Application", codeMess, EventLogEntryType.Information);
            //send to provider
            if (_twoFactorConfigs.TwoFactorEnabled)
            {
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
                        //Assign code to session...
                        //Session.Add("name", response.);
                        break;
                    case Provider.SMS:
                        var smsResponse = _smsProvider.SendMessage(_twoFactorConfigs.TwoFactorAuthFromPhone,
                            model.UserValue,
                            string.Format("Your {0} Verification code is: {1}", "Company Here", code));
                        response = new TwoFactorResponseModel()
                        {
                            Status = smsResponse.Status,
                            Message = smsResponse.Message
                        };
                        //Assign code to session...
                        break;
                    default:
                        response.Message = "Please define indicate which provider you want to use, sms or email.";
                        response.Status = false;
                        break;
                }
            }
            else
            {
                response = new TwoFactorResponseModel()
                {
                    Status = true,
                    Message = "Two factor has been disabled"
                };
            }
            return response;
        }

        public TwoFactorResponseModel VerifyCode(string code, 
            HttpSessionStateBase session, 
            HttpResponseBase httpResponse)
        {
            //create the key and send to provider
            //create a cookie by the name 
            //set the cookie life
            var response = new TwoFactorResponseModel();
            var sess = session["AuthCode"];
            if (sess != null)
            {
                var sCode = session["AuthCode"] as string;
                if (sCode.Equals(code))
                {
                    //set the cookie in the session for indicated time span
                    var cookie = new HttpCookie(_twoFactorConfigs.TwoFactorAuthCookie);
                    cookie.Value = Utils.Protect(sCode);
                    cookie.Expires = DateTime.Now.AddDays(_twoFactorConfigs.TwoFactorAuthTimeSpan);
                    httpResponse.Cookies.Add(cookie);
                    return new TwoFactorResponseModel()
                    {
                        Status = true,
                        Message = "Code was successfully verified"
                    };
                }
            }
            return new TwoFactorResponseModel()
            {
                Status = false,
                Message = "Code was not successfully verified, please try again."
            };
        }

        public TwoFactorResponseModel VerifyTwoFactor(HttpRequestBase request, 
            DateTime utcDateExpire, bool verified)
        {
            var nowUtc = DateTime.UtcNow;
            var response = new TwoFactorResponseModel();
            if (request.Cookies[_twoFactorConfigs.TwoFactorAuthCookie] != null
                && utcDateExpire > nowUtc && verified)
            {
                response.Status = true;
                response.Message = "You are verified.";
            }
            else
            {
                response.Status = false;
                response.Message = "You are not verified.";
            }
            return response;
        }
    }
    public enum Provider { Email, SMS };
}
