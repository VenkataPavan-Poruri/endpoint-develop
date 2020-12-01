using endpoint_api.voicecommerce.api;

namespace endpoint_api
{
    public interface Endpoint
    {

        public void postSale(SalePostRequest postRequest, SalePostResponse response);

    }
}
