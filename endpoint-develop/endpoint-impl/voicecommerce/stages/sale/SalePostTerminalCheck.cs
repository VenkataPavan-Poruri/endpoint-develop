using core_develop.cashflows.core.authorisation;
using core_develop.cashflows.core.model.terminal;
using datalayer.voicecommerce.model.terminal;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostTerminalCheck : SalePostPipelineStageBase
    {
        public SalePostTerminalCheck(SalePostPipelineStage next) : base(next)
        {
        }
        public override void stageExecute(SalePostContext context)
        {
            Terminal terminal;
            terminal = context.saleBuild().Terminal;
            if (terminal == null)
            {
                //Logger.warn("Terminal not found");
                context.Response.ResponseCode = ResponseCode.INVALID_TERMINAL;
            }
            else if (terminal.Status != TerminalStatus.LIVE)
            {
                //Logger.warn("Terminal is not live");
                context.Response.ResponseCode = ResponseCode.TERMINAL_NOT_LIVE;
            }
            else
            {
                //Logger.info("Terminal found.");
                nextStage(context);
            }
        }
    }
}
