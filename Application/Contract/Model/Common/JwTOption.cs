using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Model.Common
{
    public class JwTOption
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromHours(5);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
