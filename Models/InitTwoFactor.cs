using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannon.TwoFactorAuth.Models
{
    public class InitTwoFactor
    {
        public int TwoFactorAuthTimeSpan { get; set; }
        public string TwoFactorAuthCookie { get; set; }
        public string TwoFactorAuthSmtpHost { get; set; }
        public string TwoFactorAuthFromEmail { get; set; }
        public string TwoFactorAuthFromPhone { get; set; }
        public string AuthToken { get; set; }
        public string AccountSID { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string EmailPassword { get; set; }
    }
}
