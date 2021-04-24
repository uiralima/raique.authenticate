using Raique.JWT.Protocols;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raique.Authenticate.Common.Config
{
    public class JWTConfig : IJWTConfig
    {
        public int Expires => 30;

        public string Secret => "adcccbebaf6244bf9d73099613457ba7";
    }
}
