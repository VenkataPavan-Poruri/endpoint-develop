using System;
using System.Collections.Generic;
using System.Text;

namespace endpoint_service.service.xml
{
    public abstract class AuthorisationResponseXML
    {
        public string apiResponseRef;
        public readonly string messageIdent;

        public AuthorisationResponseXML(string apiResponseRef)
        {
            this.messageIdent = apiResponseRef;
        }
    }
}
