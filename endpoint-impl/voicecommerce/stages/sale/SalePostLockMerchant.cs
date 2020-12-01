using core_develop.cashflows.core.authorisation;
using datalayer.voicecommerce.model.sale;
using datalayer.voicecommerce.model.terminal;
using Action = core_develop.cashflows.core.authorisation.Action;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostLockMerchant : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        private readonly PipelineCheckCardTerminalStatisticsStageUtility cardTerminalStatsUtility;

        public SalePostLockMerchant(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostCheckCardTerminalStatistics(next, cardTerminalStatsUtility);            
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            Terminal_Lock @lock = null;

            try
            {
                Sale sale = context.saleBuild().createdSale();
                Terminal terminal = sale.Terminal;
                @lock = terminal.@lock(sale.Id.ToString(), sale.Card, context.getScheme().AuthScheme);
                if (@lock != null)
                {
                    // Have the lock.. continue on.
                    //Logger.info("Locked terminal");
                    context.setTerminalStatistics(@lock.CardStatistics, @lock.SchemeStatistics);
                    nextStg(context);
                }
                else
                {
                    // Cannot get lock - Not an error - Already locked, so indicate undesired
                    // concurrency.
                    //Logger.warn("Failed to lock terminal");

                    context.responseBuilder().ResponseCode = ResponseCode.CONCURRENT_AUTHS;
                }
            }
            finally
            {
                if (@lock != null)
                {

                    Action action;
                    ResponseCode responseCode;

                    responseCode = context.responseBuilder().ResponseCode;
                    if (responseCode != null)
                    {
                        //action = responseCode.Action;
                        action = Action.APPROVE;

                    }
                    else
                    {
                        //Logger.warn("No scheme result");
                        action = Action.DO_NOT_ACCEPT;
                    }
                    //Logger.info("Unlocking, recording Action: {}", action.name());
                    @lock.unlock(action);
                }
            }
        }
    }
}
