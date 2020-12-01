using core_develop.cashflows.endpoint.service.api;
using endpoint_models.Request;
using endpoint_service.service.xml;

namespace endpoint_service.service.handler
{
    public interface EndpointServiceRequestHandler
    {
        public abstract APIResponse handleRequest(SalePostXMLRequest apiRequest, string serviceIdent, string bid);
        //void shutdown();
    }
}
