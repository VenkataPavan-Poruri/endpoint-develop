using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostFundsRecipientSetup : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        public SalePostFundsRecipientSetup(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostTerminalCheck(next);            
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder saleBuilder;
            SalePostRequest request = context.Request;
            saleBuilder = context.saleBuild();
            if ((!string.ReferenceEquals(request.getRecipientSurname(), null)) || (request.getRecipientDOB() != null) || (!string.ReferenceEquals(request.getRecipientSurname(), null)) || (!string.ReferenceEquals(request.getDynamicAcceptorSubMerchantId(), null)))
            {
                SaleRepo.FundsRecipientBuilder recipBuilder = saleBuilder.fundsRecipientBuilder();

                recipBuilder.setSurname(request.getRecipientSurname()).setDoB(request.getRecipientDOB()).setPostalCode(request.getRecipientPostalCode()).setAccountNumber(request.getRecipientAccountNumber());

            }
            nextStg(context);
        }
    }
}
