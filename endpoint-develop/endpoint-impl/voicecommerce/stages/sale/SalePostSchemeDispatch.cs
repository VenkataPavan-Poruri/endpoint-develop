using datalayer.voicecommerce.entity.authorisation.impl;
using datalayer.voicecommerce.entity.scheme;
using datalayer.voicecommerce.model.sale;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostSchemeDispatch : SalePostPipelineStageBase
    {
        public SalePostSchemeDispatch() : base(null)
        {
        }
        public override void stageExecute(SalePostContext context)
        {
            Sale dispatchSale = context.getSale();
            Scheme dispatchScheme;
            SchemeAuthorisationResultOrResponse schemeAuthResultOrResp;
            dispatchScheme = context.getScheme();
            //Logger.info("Dispatching sale: " + dispatchSale.Id + " to scheme: " + dispatchScheme.AuthScheme);

            schemeAuthResultOrResp = dispatchScheme.authoriseSale(dispatchSale, null);
            context.responseBuilder().AuthorisationResult.SchemeAuthCode = schemeAuthResultOrResp.AuthResult.SchemeAuthCode;
            context.responseBuilder().ResponseCode = schemeAuthResultOrResp.ResponseCode;
        }
    }
}
