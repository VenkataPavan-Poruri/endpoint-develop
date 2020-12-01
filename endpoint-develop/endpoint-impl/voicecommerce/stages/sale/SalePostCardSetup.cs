using datalayer.voicecommerce.model.card;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCardSetup : SalePostPipelineStageBase
    {
        private readonly PipelineCardSetupStageUtility cardUtility;
        public SalePostCardSetup(PipelineCardSetupStageUtility cardUtils, SalePostPipelineStage next) : base(next)
        {
            cardUtility = cardUtils;
        }
        public override void stageExecute(SalePostContext context)
        {
            CardRepo_CardBuilder cardBuilder;
            SalePostRequest request = context.Request;
            cardBuilder = context.saleBuild().cardBuilder();
            cardBuilder.setNumber(cardUtility.buildCardNumber(request.getCardNumber())).setIssueDate(cardUtility.buildCardDate(request.getCardDateIssue())).setExpiryDate(cardUtility.buildCardDate(request.getCardDateExpiry())).setAVSData(cardUtility.buildAVSData(request.getCardAddress(), request.getCardPostalCode())).setCVV(request.getCardCVV());
            nextStage(context);
            throw new NotImplementedException();
        }
    }
}