using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannon.TwoFactorAuth.Util
{
    static class Helpers
    {
        internal static string GenerateRandomNumber()
        {
            Random generator = new Random();
            int r = generator.Next(1, 1000000);
            return r.ToString().PadLeft(6, '0');
        }
    }
}
