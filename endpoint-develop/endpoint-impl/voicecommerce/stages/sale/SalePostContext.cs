using datalayer.voicecommerce.entity.authorisation;
using datalayer.voicecommerce.entity.scheme;
using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public interface SalePostContext
    {
        SalePostRequest Request { get; set; }
        SalePostResponse Response { get; set; }
        SaleRepo SaleBuilder { get; set; }
        Scheme Scheme { get; set; }
        //Sale Sale { get; set; }
        ActionStatistics getTerminalCardStatistics();

        ActionStatistics getTerminalSchemeStatitics();

        void setSaleBuilder(SaleRepo.SaleBuilder builder);
        SaleRepo.SaleBuilder saleBuild();

        SaleRepo.SaleAuthorisationResponseBuilder responseBuilder();

        void setTerminalStatistics(object cardStatistics, object schemeStatistics);
        Scheme getScheme();
        Sale getSale();
    }
}