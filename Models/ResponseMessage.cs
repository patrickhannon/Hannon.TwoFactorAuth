using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannon.TwoFactorAuth.Models
{
        public class ResponseMessage
        {
            public bool Status { get; set; }
            public string Message { get; set; }

            public ResponseMessage()
            {

            }

            public ResponseMessage(bool status, string message)
            {
                ArgumentValidator.ThrowOnNullEmptyOrWhitespace("message", message);
                Status = status;
                Message = message;
            }

            public override string ToString()
            {
                return string.Format("Status: {0}, Message: {1}", Status, Message);
            }
        }
    }

