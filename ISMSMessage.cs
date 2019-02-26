using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hannon.TwoFactorAuth.Models;

namespace hannon.TwoFactorAuth
{ 
    public interface ISMSMessage
    {
        ResponseMessage SendMessage(string from, string to, string sMSmessage);
    }
}
