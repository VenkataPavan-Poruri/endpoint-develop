using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostTransactionSetup : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;

        public SalePostTransactionSetup(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostSetAuthMode(next);
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder saleBuilder;
            SalePostRequest request = context.Request;
            saleBuilder = context.saleBuild();
            saleBuilder.setGatewayRef(request.getGatewayReference()).setAuthType(request.getAuthType()).setCurrencyAmount(request.getAmount(), request.getCurrency()).setRecurrenceFlag(request.getRecurrenceFlag()).setExemptionIndicator(request.getExemptionIndicator());
            //Logger.info("Gateway Reference: " + request.GatewayReference);
            //Logger.info("Sale AuthType: " + request.AuthType + ", Recurrence: " + request.RecurrenceFlag);
            //Logger.info("Amount: " + request.Amount + " " + request.Currency.name());
            //Logger.info("Exemption Indicator: " + request.ExemptionIndicator);
            nextStg(context);
        }

    }
}