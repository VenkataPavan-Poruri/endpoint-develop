using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.authorisation;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCheckCardTerminalStatistics : SalePostPipelineStageBase
    {
        private readonly PipelineCheckCardTerminalStatisticsStageUtility cardTerminalStatsUtility;
        public SalePostCheckCardTerminalStatistics(SalePostPipelineStage next, PipelineCheckCardTerminalStatisticsStageUtility cardTerminalStatsUtility) : base(next)
        {
            this.cardTerminalStatsUtility = cardTerminalStatsUtility;
        }
        public override void stageExecute(SalePostContext context)
        {
            ActionStatistics cardStats = context.getTerminalCardStatistics();
            if (cardStats != null)
            {
                if (cardTerminalStatsUtility.isUnderThreshold(cardStats))
                {
                    // card stats ok, haven't reached the limit, so continue.
                    nextStage(context);
                }
                else
                {
                    // Limit reached...
                    context.responseBuilder().ResponseCode = ResponseCode.CARD_AUTH_LIMIT_REACHED;
                }
            }
            else
            {
                // Cannot get stats, can't guarantee won't exceed limits, so have to decline.
                //Logger.error("Cannot get card statistics - Rejecting transaction");
                context.responseBuilder().ResponseCode = ResponseCode.COULD_NOT_CHECK_AUTH_LIMIT;
            }
        }
    }
}
