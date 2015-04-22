using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace OwinDemo.Business.Models
{
    public sealed class TokenModel
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }
        
        public string audience { get; set; }
        
        public DateTime issued { get; set; }

        public DateTime expires { get; set; }
    }
}
