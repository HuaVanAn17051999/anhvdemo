using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contract.Common
{
    public class JwTAuthRepsonseModel
    {
        public string AccessToken{ get; set; }
        public DateTime ExpireIn { get; set; }
    }
}
