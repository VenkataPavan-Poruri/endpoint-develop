using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.model.sale;


namespace endpoint_api.voicecommerce.api
{
    public interface SalePostResponse
    {
        ResponseCode ResponseCode { get; set; }

        SaleAuthorisationResponse AuthorisationResponse { get; set; }
    }
}
