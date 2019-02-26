using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hannon._2factorAuth.Models;
using hannon.TwoFactorAuth.Models;
namespace hannon._2factorAuth
{
    public interface ITwoFactorAuth
    {
        TwoFactorResponseModel CreateTwoFactorAuth(TwoFactorRequestModel model);
        TwoFactorResponseModel VerifyCode(TwoFactorRequestModel model);
    }
}
