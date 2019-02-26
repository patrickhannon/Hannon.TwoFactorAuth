using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio;
using Twilio.Exceptions;
using hannon.TwoFactorAuth.Models;
namespace hannon.TwoFactorAuth.Providers
{
    internal class SmsMessageTwilio : ISMSMessage
    {
        //https://www.twilio.com/blog/2012/01/twilio-for-net-developers-part-3-using-the-twilio-rest-api-helper-library.html
        //dotnet add package Twilio
        private readonly ITwilioRestClient _client;
        private string _accountSid;
        private string _authToken;
        private string _title;

        internal SmsMessageTwilio(string accountSid, string authToken, string title)
        {
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("accountSid", accountSid);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("authToken", authToken);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("title", title);

            _accountSid = accountSid;
            _authToken = authToken;
            _title = title;
        }

        internal SmsMessageTwilio(ITwilioRestClient client)
        {
            _client = client;
        }

        public ResponseMessage SendMessage(string phoneFrom, string phoneTo, string sMSmessage)
        {
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("phoneFrom", phoneFrom);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("phoneTo", phoneTo);
            ArgumentValidator.ThrowOnNullEmptyOrWhitespace("sMSmessage", sMSmessage);

            var response = new ResponseMessage();
            try
            {
                TwilioClient.Init(_accountSid, _authToken);
                var to = new PhoneNumber(phoneTo);
                var message = MessageResource.Create(
                to,
                from: new PhoneNumber(phoneFrom),
                body: string.Format("{0}: {1}", _title, sMSmessage));

                response.Message = string.Format("The SMS text message has been successfully:{0}",
                    message.Status.ToString());
                response.Status = true;
            }
            catch (ApiException e)
            {
                response.Message = e.Message;
                response.Status = false;
            }
            return response;
        }
    }
}
