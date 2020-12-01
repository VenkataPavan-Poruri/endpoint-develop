using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostAuthenticationDataSetup : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        public SalePostAuthenticationDataSetup(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostFundsRecipientSetup(next);
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.AuthenticationDataBuilder authDataBuilder;
            SalePostRequest request = context.Request;
            //if (request.getAuthenticationECIFlag()!= null)
            //{
            authDataBuilder = context.saleBuild().authenticationDataBuilder();

            authDataBuilder.setECIFlag(request.getAuthenticationECIFlag()).setXID(request.getAuthenticationXID()).setACSData(request.getAuthenticationACSData()).set3DsVersion(request.getAuthentication3DsVersion()).setDsTransId(request.getAuthenticationDsTransId());
            //}
            nextStg(context);
        }
    }
}
