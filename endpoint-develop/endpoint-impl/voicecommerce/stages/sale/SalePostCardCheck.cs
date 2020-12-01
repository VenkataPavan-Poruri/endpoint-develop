using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.scheme;
using datalayer.voicecommerce.model.card;
using datalayer.voicecommerce.model.sale;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCardCheck : SalePostPipelineStageBase
    {
        private readonly PipelineSchemeCheckStageUtility schemeCheck;
        public SalePostCardCheck(PipelineSchemeCheckStageUtility schemeCheck, SalePostPipelineStage next) : base(next)
        {
            this.schemeCheck = schemeCheck;
        }
        public override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder builder = context.saleBuild();
            PANRange binRange = builder.getCard().getPANRange();
            Scheme scheme = schemeCheck.getSchemeFromPanRange(binRange);
            if ((binRange == null) || (scheme == null))
            {
                // TODO: Throw exception rather than this?
                context.Response.ResponseCode = ResponseCode.NO_BIN_FOR_CARD_NUMBER;
                return;
            }
            else
            {
                //Logger.info("Scheme: " + scheme.AuthScheme);
                context.Scheme = scheme;
            }
            CardDate cardExpiryDate = builder.Card.ExpiryDate;
            if (cardExpiryDate == null)
            {
                //Logger.warn("Card expiry date is outside of maximum limit");
                context.Response.ResponseCode = ResponseCode.CARD_EXPIRY_DATE_INVALID;
                return;
            }
            nextStage(context);
        }
    }
}
