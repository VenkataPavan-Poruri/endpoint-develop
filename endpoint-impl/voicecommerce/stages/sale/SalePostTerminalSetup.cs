using datalayer.voicecommerce.model.sale;
using endpoint_api.voicecommerce.api;
using System;

namespace endpoint_impl.voicecommerce.stages.sale
{
    public class SalePostTerminalSetup : SalePostPipelineStageBase
    {
        private readonly SalePostPipelineStage _nextStage;
        public SalePostTerminalSetup(SalePostPipelineStage next) : base(next)
        {
            _nextStage = new SalePostAuthenticationDataSetup(next);
        }
        protected internal override void stageExecute(SalePostContext context)
        {
            SaleRepo.SaleBuilder saleBuilder;
            SalePostRequest request = context.Request;
            saleBuilder = context.saleBuild();
            saleBuilder.setBID(request.getBID()).setMID(request.getTerminalMID()).setTID(request.getTerminalTID());
            nextStg(context);            
        }
    }
}
