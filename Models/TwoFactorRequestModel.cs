using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannon._2factorAuth.Models
{
    public class TwoFactorRequestModel
    {
        public Provider Provider { set; get; }
        public string UserValue { set; get; }
        public string Code { set; get; }
    }
}
