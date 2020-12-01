using core_develop.cashflows.endpoint.service.api;
using endpoint_api;
using endpoint_models.Request;
using endpoint_service.service.xml;

namespace endpoint_service.service.handler
{
    public abstract class AbstractEndpointServiceRequestHandler : EndpointServiceRequestHandler
    {
        public readonly Endpoint endpoint;
        public AbstractEndpointServiceRequestHandler(Endpoint endpoint)
        {
            this.endpoint = endpoint;
        }

        public abstract APIResponse handleRequest(SalePostXMLRequest apiRequest, string serviceIdent, string bid);
    }
}
