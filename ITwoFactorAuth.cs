using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hannon._2factorAuth.Models;
using hannon.TwoFactorAuth.Models;
using System.Web;
namespace hannon.TwoFactorAuth.Models
{
    public interface ITwoFactorAuth
    {
        TwoFactorResponseModel CreateTwoFactorAuth(TwoFactorRequestModel model, HttpSessionStateBase session);
        TwoFactorResponseModel VerifyCode(string code, HttpSessionStateBase session, HttpResponseBase httpResponse);
        TwoFactorResponseModel VerifyTwoFactor(HttpRequestBase request, DateTime utcDateExpire, bool verified);
    }
}
