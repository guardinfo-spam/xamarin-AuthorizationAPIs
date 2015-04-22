using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OwinDemo.Business.Models;

namespace OwinDemo.Business.Domain
{
    public sealed class AuthenticationToken
    {
        public string access_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string audience { get; set; }

        public DateTime issued { get; set; }

        public DateTime expires { get; set; }

        public AuthenticationToken(TokenModel token)
        {
            this.access_token = token.access_token;
            this.token_type = token.token_type;
            this.expires_in = token.expires_in;
            this.audience = token.audience;
            this.issued = token.issued;
            this.expires = token.expires;
        }

        public AuthenticationToken(string jsonSerializedData)
        {
            var token = JsonConvert.DeserializeObject<TokenModel>(jsonSerializedData);
            
            this.access_token = token.access_token;
            this.token_type = token.token_type;
            this.expires_in = token.expires_in;
            this.audience = token.audience;
            this.issued = token.issued;
            this.expires = token.expires;
        }

        public bool IsStillValid(DateTime currentDateTime)
        {
            return currentDateTime.CompareTo(this.expires) == -1;
        }
    }
}
