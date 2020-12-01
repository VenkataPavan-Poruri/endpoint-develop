using System;
using System.Collections.Generic;
using System.Text;

namespace endpoint_service.service.xml
{
	public abstract class SalePostXMLResponse : CostedAuthorisationResponseXML
	{
		public SalePostXMLResponse(string apiResponseRef) : base(apiResponseRef)
		{
		}
	}

}
