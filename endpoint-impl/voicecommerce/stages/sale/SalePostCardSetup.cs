using datalayer.voicecommerce.model.card;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCardSetup : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly PipelineCardSetupStageUtility _cardUtility;
        private readonly PipelineSchemeCheckStageUtility _schemeCheck;

        public SalePostCardSetup(PipelineCardSetupStageUtility cardUtils, SalePostPipelineStage next) : base(next)
        {
            _cardUtility = cardUtils;
            _nextStage = new SalePostCardCheck(_schemeCheck, next);
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            CardRepo_CardBuilder cardBuilder;
            SalePostRequest request = context.Request;
            cardBuilder = context.saleBuild().cardBuilder();
            cardBuilder.setNumber(_cardUtility.buildCardNumber(request.getCardNumber())).setIssueDate(_cardUtility.buildCardDate(request.getCardDateIssue())).setExpiryDate(_cardUtility.buildCardDate(request.getCardDateExpiry())).setAVSData(_cardUtility.buildAVSData(request.getCardAddress(), request.getCardPostalCode())).setCVV(request.getCardCVV());
            nextStg(context);
            throw new NotImplementedException();
        }
    }
}