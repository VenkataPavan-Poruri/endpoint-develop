using core_develop.cashflows.endpoint.service.api;
using endpoint_api;
using endpoint_models.Request;
using endpoint_service.service.xml;
using System;
using endpoint_impl.voicecommerce.stages;
using endpoint_impl.voicecommerce.stages.sale;

namespace endpoint_service.service.handler
{
    public class EndpointServiceRequestHandlerImpl : AbstractEndpointServiceRequestHandler
    {
        public EndpointServiceRequestHandlerImpl(Endpoint endpoint) : base(endpoint)
        {

        }
        public override APIResponse handleRequest(SalePostXMLRequest apiRequest, string serviceIdent, string bid)
        {
            APIResponse response = null;
            response = authorise(apiRequest, bid);
            return response;

            //if ((apiRequest is SalePostXMLRequest))
            //{
            //SalePostXMLRequest saleReq = ((SalePostXMLRequest)(apiRequest));
            //response = authorise(apiRequest, bid);
            //}
        }
        public APIResponse authorise(SalePostXMLRequest apiRequest, string bid)
        {
            //throw new NotImplementedException();
            EPSSalePostResponseImpl response = new EPSSalePostResponseImpl(apiRequest);
            endpoint.postSale(new EPSSalePostRequestImpl(apiRequest, bid), response);
            // return null;
            return response.getXML();
        }
    }
}
