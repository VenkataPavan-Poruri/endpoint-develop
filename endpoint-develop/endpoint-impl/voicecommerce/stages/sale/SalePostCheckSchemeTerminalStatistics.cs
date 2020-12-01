﻿using core_develop.cashflows.common;
using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.entity.authorisation;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostCheckSchemeTerminalStatistics : SalePostPipelineStageBase
    {
        private readonly PipelineCheckSchemeTerminalStatisticsStageUtility terminalStatsCheckUtility;
        public SalePostCheckSchemeTerminalStatistics(SalePostPipelineStage next, PipelineCheckSchemeTerminalStatisticsStageUtility terminalStatsCheckUtility) : base(next)
        {
            this.terminalStatsCheckUtility = terminalStatsCheckUtility;
        }
        public override void stageExecute(SalePostContext context)
        {
            ActionStatistics schemeStats = context.getTerminalSchemeStatitics();
            AuthScheme scheme = context.saleBuild().AuthScheme;
            if ((scheme != null) && (schemeStats != null))
            {
                if (terminalStatsCheckUtility.isUnderThreshold(schemeStats, scheme))
                {
                    nextStage(context);
                }
                else
                {
                    // Over threshold and approval rate too low - Block the transaction.
                    context.responseBuilder().ResponseCode = ResponseCode.SCHEME_AUTH_LIMIT_REACHED;
                }
            }
            else
            {
                // Cannot get stats, can't guarantee won't exceed limits, so have to decline.
                //Logger.error("Cannot get scheme statistics, or determine scheme - " + "Rejecting transaction");
                context.responseBuilder().ResponseCode = ResponseCode.COULD_NOT_CHECK_AUTH_LIMIT;
            }
        }
    }
}
